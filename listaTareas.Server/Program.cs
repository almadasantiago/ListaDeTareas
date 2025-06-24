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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
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

app.MapGet("/api/tareas", (int idUsuario, int pagina, int tamanioPagina, ITareaRepositorio repo) =>
{
    var result = repo.ListarPaginado(idUsuario, pagina, tamanioPagina);
    return Results.Ok(result);
});


app.MapPost("/api/tareas/crear", async (TareaDTO dto, CasoDeUsoTareaAlta caso) =>
{
    try
    {
        caso.Ejecutar(dto.Nombre, dto.Descripcion, dto.IdUsuario);
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

app.MapPut("/api/tareas/modificar", async (TareaDTO dto, CasoDeUsoModificarTarea caso) =>
{
     caso.Ejecutar(dto.Id, dto.Nombre, dto.Descripcion, dto.IdUsuario);
    return Results.Ok("Tarea modificada");
});



app.Run();
