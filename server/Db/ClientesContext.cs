using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db
{
    public class ClientesContext: DbContext
    {

        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options) { }

        public DbSet<Clientes> clientes { get; set; }
    }
}
