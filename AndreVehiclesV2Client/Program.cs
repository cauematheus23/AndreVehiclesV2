using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndreVehiclesV2Client.Data;
using AndreVehiclesV2AdressAPI.Integration.Interfaces;
using AndreVehiclesV2AdressAPI.Integration.Refit;
using AndreVehiclesV2AdressAPI.Integration;
using Refit;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AndreVehiclesV2ClientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AndreVehiclesV2ClientContext") ?? throw new InvalidOperationException("Connection string 'AndreVehiclesV2ClientContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICepAPI, CepAPI>();

builder.Services.AddRefitClient<ICepAPIRefit>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br")); // Ajuste para o URL correto da sua API

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

app.Run();
