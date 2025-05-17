using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.API.Models;
using NajotTalim.HR.API.Services;
using NajotTalim.HR.DataAcces;
using NajotTalim.HR.DataAcces.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb")));
builder.Services.AddScoped<IGenericCRUDService<EmployeeModel>, EmployeeCRUDService>();
builder.Services.AddScoped<IGenericCRUDService<AdressModel>, AdressCRUDService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IGenericRepository<Adress>, AdressRepository>();
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
