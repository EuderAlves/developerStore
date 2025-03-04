using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using DeveloperStoreBack.Infrastructure.Data.Contexts;
using DeveloperStoreBack.Application.Services;
using DeveloperStoreBack.Infrastructure.Data.Repositories;
using DeveloperStoreBack.Domain.Repositories;
using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddSingleton<SaleService>();
builder.Services.AddSingleton<SaleNotificationService>();
builder.Services.AddSingleton<ISaleRepository, SaleRepository>();

builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<IItemRepository, ItemRepository>();

builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var settings = builder.Configuration.GetSection("ConnectionStrings");
    var connectionString = settings["MongoDb"]; 
    var databaseName = "developer_store";

    if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
    {
        throw new Exception("A conexão com o MongoDB não foi configurada corretamente.");
    }

    return new MongoDbContext(connectionString, databaseName);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeveloperStore API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();