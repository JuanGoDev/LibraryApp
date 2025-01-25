using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Shared.Entities;

namespace BibliotecaApp.Infrastructure.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; } = null!;
        public DbSet<Autor> Autores { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Libro
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Nombre).IsRequired().HasMaxLength(200);
                entity.HasOne(l => l.Autor)
                    .WithMany(a => a.Libros)
                    .HasForeignKey(l => l.AutorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Autor
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(a => a.PaisNacimiento).HasMaxLength(100);
            });

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(u => u.LugarResidencia).HasMaxLength(200);
            });
        }
    }
} 