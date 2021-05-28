using Administracion.Hotel.Api.AccesoDatos;
using Administracion.Hotel.Api.Negocio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = userInfo.Email, Email = userInfo.Email };
                ApplicationUser use1r = new ApplicationUser { UserName = userInfo.Email, Email = userInfo.Email };

                var result = await _userManager.CreateAsync(user, userInfo.Password);
                if (result.Succeeded)
                {
                    return BuildToken(userInfo);
                }
                else
                {
                    return BadRequest("El Usuario no pudo ser creado");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Username, userInfo.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //Usuario usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Email == userInfo.Email);

                    //if (usuario.Id != 0)
                    //{
                    //    userInfo.Identificacion = usuario.Id;
                    //}
                    userInfo.Email = userInfo.Username;

                    //usuario.Estado = 1;
                    //context.Entry(usuario).State = EntityState.Modified;
                    //context.SaveChanges();
                    return BuildToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no  fue válido");
                return BadRequest(ModelState);
            }
        }


       [Route("ActualizarContrasena")]
        [HttpPost]
        public async Task<IActionResult> ActualizarContrasena([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userInfo.Email);
                var result = await _userManager.ChangePasswordAsync(user, userInfo.Password, userInfo.NewPassword);
                if (result.Succeeded)
                {

                    return BadRequest("La contraseña fue actualizada correctamente");
                }
                else
                {
                    return BadRequest("la contraseña no puede ser actualizada");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("ValidarExiteUsuario")]
        [HttpPost]
        public async Task<IActionResult> ValidarExisteUsuario([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var existeUsuario = await _userManager.FindByEmailAsync(userInfo.Email);
                if (existeUsuario == null || existeUsuario.Id == "")
                {
                    userInfo.ExisteUsuario = false;
                    return BadRequest("El usuario con el correo " + userInfo.Email + " no existe");

                }
                else
                {
                    userInfo.ExisteUsuario = true;
                    return BadRequest("El usuario con el correo " + userInfo.Email + " ya existe");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AFKDJSKAFJPWEQIFSDKVNJKSVNSJKADFNWPEPNGFPUEQGRSDVJKDNZZAQFKSDFKKSFD"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "grupomas.com",
                audience: "grupomas.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                idUsuario = userInfo.Identificacion


            });
        }
    }
}
