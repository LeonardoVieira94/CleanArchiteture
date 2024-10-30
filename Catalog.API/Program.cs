using Catalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Catalog.CrossCutting;
using Catalog.CrossCutting.IoC;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCatalogDependencies(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var options = new JsonSerializerOptions
{
    IgnoreNullValues = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

string mySqlConnection = builder.Configuration.GetConnectionString("Catalog");
builder.Services.AddDbContext<AppDbContext>(options =>
                                  options.UseMySql(mySqlConnection,
                                  ServerVersion.AutoDetect(mySqlConnection),
                                  b => b.MigrationsAssembly("Catalog.Infrastructure")));


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
