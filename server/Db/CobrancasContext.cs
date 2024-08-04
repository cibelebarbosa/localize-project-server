using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Db
{
    public class CobrancasContext: DbContext
    {
        

            public CobrancasContext(DbContextOptions<CobrancasContext> options) : base(options) { }

            public DbSet<Cobrancas> cobrancas { get; set; }
        
    }
}
