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

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().HasKey("._id");

            modelBuilder.Entity<Usuario>()
                .Property<string>("_nombreusuario")
                .HasColumnName("NombreUsuario")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property<string>("_password")
                .HasColumnName("Password")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property<string>("_correo")
                .HasColumnName("Correo")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .HasMany<Tarea>("tareas")
                .WithOne("usuario")
                .HasForeignKey("UsuarioId")
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tarea>().ToTable("Tareas");
            modelBuilder.Entity<Tarea>().HasKey("._id");

            modelBuilder.Entity<Tarea>()
                .Property<string>("_nombre")
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Tarea>()
                .Property<string>("_descripcion")
                .HasColumnName("Descripcion")
                .HasMaxLength(500);

            modelBuilder.Entity<Tarea>()
                .Property<DateTime>("_fecha")
                .HasColumnName("Fecha")
                .IsRequired();

            modelBuilder.Entity<Tarea>()
                .Property<bool>("finalizo")
                .HasColumnName("Finalizo")
                .IsRequired();

            modelBuilder.Entity<Tarea>()
                .Property<int>("UsuarioId")
                .HasColumnName("UsuarioId")
                .IsRequired();
        }
    }
}
