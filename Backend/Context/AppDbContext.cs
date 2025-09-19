using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class AppDbContext : DbContext // DbContext objeto pertenciente de entity 
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> Carreras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(tb =>
            {
                tb.HasKey(col => col.IdCarrera);
                tb.Property(col => col.IdCarrera).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.ToTable("Carrera");
            });
            
            modelBuilder.Entity<Estudiante>(tb =>
            {
                tb.HasKey(col => col.IdEstudiante);
                tb.Property(col => col.IdEstudiante).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.NombreCompleto).HasMaxLength(100);
                tb.Property(col => col.Telefono).HasMaxLength(15);
                tb.HasOne(col => col.Carrera).WithMany(c => c.Estudiantes).HasForeignKey(col => col.IdCarrera);
                tb.ToTable("Estudiante");
            });
        }
    }
}