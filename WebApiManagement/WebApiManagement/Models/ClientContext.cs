using Microsoft.EntityFrameworkCore;
using WebApiManagement.Models;

namespace WebApiManagement.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = null!;
    }
}
