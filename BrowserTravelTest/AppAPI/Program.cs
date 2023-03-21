using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Configure DbContext
builder.Services.AddDbContext<BrowserTravelTestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BrowserTravelTestDb")));

// Register services
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IEditorialService, EditorialService>();
builder.Services.AddScoped<IBookAuthorService, BookAuthorService>();

// Register repositories
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IEditorialRepository, EditorialRepository>();
builder.Services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrowserTravelTest", Version = "v1" });
});

var app = builder.Build();

// Configure Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrowserTravelTest v1"));

// Configure endpoints
app.MapControllers();

app.Run();
