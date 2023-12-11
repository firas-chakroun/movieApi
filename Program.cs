using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using movieApi.Models;
using movieApi.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient < IGenresService,GenresService >();
builder.Services.AddTransient<IMoviesService,MoviesService >();
builder.Services.AddAutoMapper(typeof(Program));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));
builder.Services.AddCors();




builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "MoviesApi",
            Description = "My first api",
            TermsOfService = new Uri("https://www.google.com"),
            Contact = new OpenApiContact
            {
                Name = "your company name",
                Email = "test@domain . corn",
                Url = new Uri("https://www.google.com")
            },
            License = new OpenApiLicense
            {
                Name = "My license",
                Url = new Uri("https://www.google.com")

            }
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();

app.Run();
