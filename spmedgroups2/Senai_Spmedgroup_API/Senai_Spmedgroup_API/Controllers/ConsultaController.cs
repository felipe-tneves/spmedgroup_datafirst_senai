using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ConsultaRepository.ListaConsulta());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }

        [HttpPost]
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

        [HttpGet("logado")]
        public IActionResult List()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(usuario => usuario.Type == JwtRegisteredClaimNames.Jti).Value);
                int IdTipoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(usuario => usuario.Type == ClaimTypes.Role).Value);
                return Ok(ConsultaRepository.ListConsultaUsuario(IdUsuario, IdTipoUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }


    }
}