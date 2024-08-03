using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Db;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {

        private UserContext _context;

        public UserController(UserContext context)
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

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.users;
        }

        [HttpGet("{id}")]
        public User? GetUserId(int id)
        {
            return _context.users.FirstOrDefault(user => user.user_id == id);
        }
    }
}
