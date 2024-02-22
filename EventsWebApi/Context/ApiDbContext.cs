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
                .HasKey(je => new { je.UserId, je.EventId });

            builder.Entity<JoinedEvents>()
                .HasOne(je => je.Event)
                .WithMany(g=>g.JoinedEvents)
                .HasForeignKey(je => je.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<JoinedEvents> JoinedEvents { get; set; }
    }
}