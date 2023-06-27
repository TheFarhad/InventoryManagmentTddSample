using Microsoft.EntityFrameworkCore;
using IM.Application.Contract;
using IM.Application.Inventory;
using IM.Domain.Inventory;
using IM.Infrastructure.Context;
using IM.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var cnn = builder.Configuration.GetConnectionString("InventoryConnectionString");
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IInventoryApplication, InventoryApplication>();
builder.Services.AddDbContext<IMContext>(_ =>
{
    _.UseSqlServer(cnn);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }