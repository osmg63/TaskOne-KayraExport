using Microsoft.EntityFrameworkCore;
using TaskOneKayraExport.Data.Context;
using TaskOneKayraExport.Data.ProductMapper;
using TaskOneKayraExport.Data.Repository;
using TaskOneKayraExport.Exceptions;
using TaskOneKayraExport.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskOneKayraExport.Data.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ExceptionMiddleware>();



builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ProductRequestDtoValidator>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProductMapper>();
});
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

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
