using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Spmedgroup_API.Interfaces;
using Senai_Spmedgroup_API.Repositories;

namespace Senai_Spmedgroup_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository ProntuarioRepository { get; set; }

        public ProntuarioController()
        {
            ProntuarioRepository = new ProntuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ProntuarioRepository.ListProntuario());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }
    }
}