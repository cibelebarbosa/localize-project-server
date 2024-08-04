using Microsoft.AspNetCore.Mvc;
using server.Db;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class userController : ControllerBase
    {

        private UserContext _context;

        public userController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserId), new { id = user.user_id }, user);
        }


        [HttpPost("login")]
        public IActionResult GetUserId([FromBody] Login request)
        {
            var user = _context.users.FirstOrDefault(user => user.email == request.email && user.password == request.password);
            if (user == null)
            {
                return NotFound(new { Message = "Atenção: E-mail ou senha inválidos" });
            }
            return Ok(user);
        }
    }
}
