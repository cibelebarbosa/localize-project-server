using Microsoft.AspNetCore.Mvc;
using server.Db;
using server.Models;
using System;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class cobrancasController: ControllerBase
    {
        private CobrancasContext _context;

        public cobrancasController(CobrancasContext context)
        {
            _context = context;
        }

        [HttpPost("cobranca")]
        public IActionResult AddCobranca([FromBody] Cobrancas cobranca)
        {
            cobranca.data = cobranca.data.ToUniversalTime();

            _context.cobrancas.Add(cobranca);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCobrancaId), new { id = cobranca.cobranca_id }, cobranca);
        }

        [HttpGet("cobranca/{id}")]
        public IActionResult GetCobrancaId(int id)
        {
            var cobranca = _context.cobrancas.FirstOrDefault(c => c.cobranca_id == id);
            if (cobranca == null)
            {
                return NotFound(new { Message = "Cobrança não encontrada" });
            }
            return Ok(cobranca);

        }


        [HttpGet("{client_id}")]
        public IActionResult GetCobrancasByClient(int client_id)
        {
            var cobrancas = _context.cobrancas.Where(c => c.client_id == client_id).ToList();
            if (cobrancas.Count == 0)
            {
                return NotFound(new { Message = "Cliente não encontrado" });
            }
            return Ok(cobrancas);
        }
    }
}
