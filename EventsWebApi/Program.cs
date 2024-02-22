using EventsWebApi.Context;
using EventsWebApi.Repository;
using EventsWebApi.Repository.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IJoinedEventsRepository, JoinedEventsRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApiDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        var hasAppliedMigrations = context.Database.GetAppliedMigrations().Any();

        if (!hasAppliedMigrations)
        {
            context.Database.Migrate();
        }
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
