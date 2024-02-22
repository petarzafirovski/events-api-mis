using EventsWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApi.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JoinedEvents>()
            .HasKey(je => new { je.EventId, je.UserId });

            builder.Entity<JoinedEvents>()
                .HasOne(je => je.Event)
                .WithMany()
                .HasForeignKey(je => je.EventId);
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<JoinedEvents> JoinedEvents { get; set; }
    }
}