using Microsoft.EntityFrameworkCore;
using VirtualServiceWeb.Data;
using VirtualServiceWeb.Data.DbSeed;
using VirtualServiceWeb.Repositories.Implementations;
using VirtualServiceWeb.Repositories.Interfaces;
using VirtualServiceWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInstanceRepository, InstanceRepository>();
builder.Services.AddScoped<IDbSeed, DbSeed>();
builder.Services.AddScoped<CoreService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DockerLocal")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();


using(var scope = scopeFactory.CreateScope())
{
    var dbSeed = scope.ServiceProvider.GetService<IDbSeed>();
    dbSeed?.Seed();
}

app.Run();