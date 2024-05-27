using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeniorTeste.BackgroudService;
using SeniorTeste.Infra.Data;
using SeniorTeste.Service.Interface;
using SeniorTeste.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(DbContext), typeof(DataContext));

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped(typeof(IOpenWeatherService), typeof(OpenWeatherService));
builder.Services.AddScoped(typeof(ICidadeService), typeof(CidadeService));
builder.Services.AddScoped(typeof(IClimaService), typeof(ClimaService));
builder.Services.AddHttpClient();
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
