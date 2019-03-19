using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository ClinicaRepository { get; set; }

        public ClinicaController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        //cadastra consulta 
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarConsulta(Clinica clinica)
        {
            try
            {
                ClinicaRepository.Cadastrar(clinica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }
    }
}