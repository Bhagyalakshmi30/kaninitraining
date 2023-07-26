using Microsoft.EntityFrameworkCore;
using BloodDB.Model;
using BloodDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BloodDbContext>(optionsAction: options => options.UseSqlServer(builder.Configuration.GetConnectionString(name: "SQLConnection")));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDonorService, DonorService>();

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
