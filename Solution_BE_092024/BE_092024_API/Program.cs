using BE_092024.DataAccess.NetCore.DAL;
using BE_092024.DataAccess.NetCore.DALImpl;
using BE_092024.DataAccess.NetCore.DBContext;
using BE_092024_API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<BE_092924DbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<MyCustomeMiddleware>();

app.MiddlewareOfBE092024();

app.UseAuthorization();

app.MapControllers();

app.Run();
