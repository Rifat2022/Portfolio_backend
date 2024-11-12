using Microsoft.EntityFrameworkCore;
using Porfolio.BusinessLogic;
using Porfolio.Data;
using Porfolio.Interfaces;
using Porfolio.Repositories;
using Porfolio.Services;
using Porfolio.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioDb")));

builder.Services.AddScoped<CustomerReviewBusinessLogic>();
builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();
builder.Services.AddScoped<CustomerReviewService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewService>();
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
