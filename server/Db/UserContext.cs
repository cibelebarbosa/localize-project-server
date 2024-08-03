using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
    }
}
