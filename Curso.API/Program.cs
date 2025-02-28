using Curso.API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContex>(x => x.UseSqlServer("name=DockerConn"));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer(); // Necesario para Swagger
builder.Services.AddSwaggerGen(); // Agregar Swagger

var app = builder.Build();
/*
app.MapGet("/", (HttpContext contex) =>
{
    contex.Response.Redirect("/swagger/index.html", permanent: false);
});
*/
app.Use(async (contex, next) =>
{
    if (contex.Request.Path == "/")
    {
        contex.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Habilitar Swagger
    app.UseSwaggerUI(); // Habilitar la interfaz de usuario de Swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
