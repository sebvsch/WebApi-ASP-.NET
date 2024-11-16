

using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options)
        : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}