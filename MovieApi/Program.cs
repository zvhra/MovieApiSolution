using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "🎬 Zahra's Movie API",
        Version = "v1",
        Description = "A simple RESTful API to manage movies using ASP.NET Core & SQLite."
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Seed.Initialize(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zahra's Movie API v1");
        c.IndexStream = () =>
            File.OpenRead(Path.Combine(builder.Environment.WebRootPath, "swagger-ui", "index.html"));
    });
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
