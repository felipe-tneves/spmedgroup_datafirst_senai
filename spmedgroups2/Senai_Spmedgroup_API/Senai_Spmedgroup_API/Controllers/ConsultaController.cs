using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using Senai_Spmedgroup_API.Repositories;

namespace Senai_Spmedgroup_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultaController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        //cadastra consulta 
        [HttpPost]
        [Authorize (Roles="1")]
        public IActionResult CadastrarConsulta(Consulta consulta)
        {
            try
            {
                ConsultaRepository.CadastrarConsulta(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }

        // mostra lista de consulta 
        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(usuario => usuario.Type == JwtRegisteredClaimNames.Jti).Value);
                int idTipoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(usuario => usuario.Type == ClaimTypes.Role).Value);
                return Ok(ConsultaRepository.ListConsultaUsuario(idUsuario, idTipoUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex });
            }
        }


    }
}