using Microsoft.AspNetCore.Mvc;
using server.Db;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class clientesController : ControllerBase
    {
        private ClientesContext _context;
        private CobrancasContext _cobrancaContext;

        public clientesController(ClientesContext context, CobrancasContext cobrancasContext)
        {
            _context = context;
            _cobrancaContext = cobrancasContext;
        }

        [HttpPost("cliente")]
        public IActionResult AddCliente([FromBody] Clientes cliente)
        {
            _context.clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteId), new { id = cliente.client_id }, cliente);
        }

        [HttpGet("cliente/{id}")]
        public IActionResult GetClienteId(int id)
        {
            var cliente = _context.clientes.FirstOrDefault(c => c.client_id == id);
            if (cliente == null)
            {
                return NotFound(new { Message = "Cliente not found or invalid credentials" });
            }
            return Ok(cliente);

        }

        [HttpGet("{user_id}")]
        public IActionResult GetClientesByUser(int user_id)
        {
            var clientes = _context.clientes.Where(c => c.user_id == user_id).ToList();
            if (clientes.Count == 0)
            {
                return NotFound(new { Message = "No clients found for the specified user ID" });
            }
            return Ok(clientes);
        }

        [HttpGet("cliente-info/{id}")]
        public IActionResult GetClienteInfo(int id)
        {
            var cliente = _context.clientes.FirstOrDefault(c => c.client_id == id);
            if (cliente == null)
            {
                return NotFound(new { Message = "Cliente not found" });
            }
            var cobrancas = _cobrancaContext.cobrancas.Where(c => c.client_id == id).ToList();
            var pago = cobrancas.Count(c => c.pago);
            var abertos = cobrancas.Count(c => !c.pago && c.data >= DateTime.Now.Date);
            var atrasados = cobrancas.Count(c => !c.pago && c.data < DateTime.Now.Date);
            var response = new ClientesResponse
            {
                client_id = cliente.client_id,
                nome = cliente.nome,
                pago = pago,
                abertos = abertos,
                atrasados = atrasados
            };
            return Ok(response);
        }

        [HttpGet("clientes-info-by-user/{user_id}")]
        public IActionResult GetClientesInfoByUser(int user_id)
        {
            var clientes = _context.clientes.Where(c => c.user_id == user_id).ToList();
            if (clientes.Count == 0)
            {
                return NotFound(new { Message = "No clients found for the specified user ID" });
            }
            var clientesInfo = new List<ClientesResponse>();
            foreach (var cliente in clientes)
            {
                var response = GetClienteInfo(cliente.client_id) as OkObjectResult;
                if (response != null)
                {
                    var clienteResponse = response.Value as ClientesResponse;
                    if (clienteResponse != null)
                    {
                        clientesInfo.Add(clienteResponse);
                    }
                }
            }
            return Ok(clientesInfo);
        }


    }
}
