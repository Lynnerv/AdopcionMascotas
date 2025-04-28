using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Adopcion> Adopciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 Relación 1:1 Mascota - Adopcion
            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Adopcion)
                .WithOne(a => a.Mascota)
                .HasForeignKey<Adopcion>(a => a.MascotaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔥 Relación 1:N Adoptante - Adopciones
            modelBuilder.Entity<Adopcion>()
                .HasOne(a => a.Adoptante)
                .WithMany(adoptante => adoptante.Adopciones)
                .HasForeignKey(a => a.AdoptanteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    
}
