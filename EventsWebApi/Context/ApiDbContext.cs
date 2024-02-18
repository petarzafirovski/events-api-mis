using EventsWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApi.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
        
        public DbSet<Event> Events { get; set; }
    }
}