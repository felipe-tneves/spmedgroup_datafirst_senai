using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using Senai_Spmedgroup_API.Repositories;
using Senai_Spmedgroup_API.ViewModels;

namespace Senai_Spmedgroup_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set;}
        
        public LoginController()
        {
            UsuarioRepository = new UsarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuario não encontrado, por favor digite novamente" });
                }

                var claims = new[]
                {
                   new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                   new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                   new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "Spmedgroup",
                    audience: "Spmedgroup",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
                
            }
        }
    }
}