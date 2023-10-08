using Core.Interfaces;
using Infrastracture.Data;
using Infrastracture.Data.Repositories;
using Infrastracture.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDBContext>(x=>x.UseSqlite($"Data Source=FirstAngularAppDB.db"));// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductsRepository,ProductsRepository>();
var app = builder.Build();

using (var scop=app.Services.CreateScope())
{
    var services=scop.ServiceProvider;
    var loggerFactory=services.GetRequiredService<ILoggerFactory>();

    try{
        var context=services.GetRequiredService<StoreDBContext>();
        await context.Database.MigrateAsync();
        
        await StoreContextSeed.SeedAsync(context,loggerFactory);
    }
    catch(Exception ex)
    {
        var logger=loggerFactory.CreateLogger<Program>();
        logger.LogError(ex,"An error occured during migration");
    }
}


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
