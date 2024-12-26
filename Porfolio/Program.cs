using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Repositories;
using Porfolio.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using Porfolio.Repositories.Interface;
using Porfolio.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Database context
builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioDb")));

// Dependency Injection of Repositoris
builder.Services.AddScoped<IFileDetailsRepository, FileDetailsRepository>();
builder.Services.AddScoped<IOfferedServiceRepository, OfferedServiceRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();
// Dependency Injection of Services

builder.Services.AddScoped<ICustomerReviewService, CustomerReviewService>();
builder.Services.AddScoped<IOfferedServicesService, OfferedServicesService>();
builder.Services.AddScoped<IFileDetailsService, FileDetailsService>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Form options for large file uploads
builder.Services.Configure<FormOptions>(o =>
{   
    o.ValueLengthLimit = 50 * 1024 * 1024; // 50 MB
    o.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50 MB
    o.MemoryBufferThreshold = 1 * 1024 * 1024; // 1 MB
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 50 * 1024 * 1024; // 50 MB
});
// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseCors("AllowLocalhost4200");

// Static files
var resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
if (!Directory.Exists(resourcesPath))
{
    Directory.CreateDirectory(resourcesPath);
}
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(resourcesPath),
    RequestPath = "/Resources"
});

// HTTPS
app.UseHttpsRedirection();

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();
