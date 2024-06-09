using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndreVehiclesV2AdressAPI.Data;
using Models.APIs;
using Refit;
using AndreVehiclesV2AdressAPI.Integration.Refit;
using AndreVehiclesV2AdressAPI.Integration.Interfaces;
using AndreVehiclesV2AdressAPI.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AndreVehiclesV2AdressAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AndreVehiclesV2AdressAPIContext") ?? throw new InvalidOperationException("Connection string 'AndreVehiclesV2AdressAPIContext' not found.")));

// Add services to the container.
builder.Services.AddRefitClient<ICepAPIRefit>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br"));

builder.Services.AddTransient<ICepAPI, CepAPI>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
