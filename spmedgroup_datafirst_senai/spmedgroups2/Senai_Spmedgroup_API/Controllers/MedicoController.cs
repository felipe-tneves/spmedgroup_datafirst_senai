using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Spmedgroup_API.Repositories;

namespace Senai_Spmedgroup_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository MedicoRepository { get; set; }

        public MedicoController()
        {
            MedicoRepository = new MedicoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(MedicoRepository.ListaMed());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }
    }
}