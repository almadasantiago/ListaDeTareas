using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Infraestructura.Persistencia;
using listaTareas.Server.Repositorios;
using Microsoft.EntityFrameworkCore;
using listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario;
using listaTareas.Server.Aplicacion.Validadores;
using listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoTarea;
using listaTareas.Server.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITareaRepositorio, TareaRepositorios>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorios>();
builder.Services.AddScoped<UsuarioValidador>();
builder.Services.AddScoped<CasoDeUsoUsuarioAlta>();
builder.Services.AddScoped<CasoDeUsoUsuarioIniciarSesion>();
builder.Services.AddScoped<CasoDeUsoUsuarioModificar>();
builder.Services.AddScoped<CasoDeUsoTareaAlta>();
builder.Services.AddScoped<CasoDeUsoTareaBaja>();
builder.Services.AddScoped<CasoDeUsoListarTareas>();
builder.Services.AddScoped<CasoDeUsoModificarTarea>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("PermitirFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.MapPost("/api/usuarios/registrar",
    async (UsuarioDTO dto, CasoDeUsoUsuarioAlta caso) =>
    {
        try
        {
            caso.Ejecutar(dto.NombreUsuario, dto.Password, dto.Correo);
            return Results.Ok("Usuario registrado");
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    });

app.MapPost("/api/usuarios/login",
    async (UsuarioLoginDTO dto, CasoDeUsoUsuarioIniciarSesion caso) =>
    {
        try
        {
            int id = caso.Ejecutar(dto.NombreUsuario, dto.Password);
            return Results.Ok(new { idUsuario = id });
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    });

app.MapGet("/api/tareas/{idUsuario}", (int idUsuario, CasoDeUsoListarTareas caso) =>
{
    try
    {
        var tareas = caso.Ejecutar();
        return Results.Ok(tareas);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapPost("/api/tareas/crear", async (TareaDTO dto, CasoDeUsoTareaAlta caso) =>
{
    try
    {
        caso.Ejecutar(dto.Titulo, dto.Descripcion, dto.idUsuario);
        return Results.Ok("Tarea creada");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});


app.MapDelete("/api/tareas/{id}", (int id, CasoDeUsoTareaBaja caso) =>
{
    try
    {
        caso.Ejecutar(id);
        return Results.Ok("Tarea finalizada");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();
