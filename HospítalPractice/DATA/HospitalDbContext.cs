using HospítalPractice.MODELS;
using Microsoft.EntityFrameworkCore;

namespace HospítalPractice.DATA
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base (options)
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Medico> Meidco { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<CitaMedico> CitaMedicos { get; set; }
        public DbSet<SignosVitales> SignosVitales { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<DetalleReceta> DetalleRecetas { get; set; }
        public DbSet<CitaMedicaDiagnostico> CitaMedicaDiagnosticos { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitaMedico>()
                .HasOne(cm => cm.Medico)
                .WithMany()
                .HasForeignKey(cm => cm.Medico_Id)
                .OnDelete(DeleteBehavior.Restrict);  // O DeleteBehavior.NoAction

            modelBuilder.Entity<CitaMedico>()
                .HasOne(cm => cm.Receta)
                .WithMany()
                .HasForeignKey(cm => cm.Receta_id)
                .OnDelete(DeleteBehavior.Restrict);  // O DeleteBehavior.NoAction

            modelBuilder.Entity<CitaMedico>()
                .HasOne(cm => cm.Diagnostico)
                .WithMany()
                .HasForeignKey(cm => cm.Diagnostico_id)
                .OnDelete(DeleteBehavior.Restrict);  // O DeleteBehavior.NoAction
        }
    }
}
