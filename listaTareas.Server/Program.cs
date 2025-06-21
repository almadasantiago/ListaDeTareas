using listaTareas.Server.Aplicacion.Interfaces;
using listaTareas.Server.Infraestructura.Persistencia;
using listaTareas.Server.Repositorios;
using Microsoft.EntityFrameworkCore;
using listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoUsuario;
using listaTareas.Server.Aplicacion.Validadores;
using listaTareas.Server.Aplicacion.CasosDeUso.CasosDeUsoTarea;
using listaTareas.Server.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

app.UseCors("PermitirFrontend");

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
