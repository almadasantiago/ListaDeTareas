using Microsoft.EntityFrameworkCore;
using listaTareas.Server.Aplicacion.Entidades;

namespace listaTareas.Server.Infraestructura.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nombreusuario)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(u => u.Password)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(u => u.Correo)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.HasMany(u => u.Tareas)
                    .WithOne(t => t.Usuario) 
                    .HasForeignKey(t => t.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tareas");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(t => t.Descripcion)
                    .HasMaxLength(500);

                entity.Property(t => t.Fecha).
                HasColumnType("datetime2").
                IsRequired(); 

                entity.Property(t => t.Finalizo)
                    .IsRequired();

                entity.Property(t => t.UsuarioId)
                    .IsRequired();

                entity.HasOne(t => t.Usuario) 
                      .WithMany(u => u.Tareas)
                      .HasForeignKey(t => t.UsuarioId);
            });
        }
    }
}
