using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BetterLife.Models;

public class BetterLifeContext : DbContext
{
    public BetterLifeContext() : base("name=ConexionBLDB") { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Profesional> Profesionales { get; set; }
    public DbSet<Rutinas> Rutinas { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Rutinas>()
            .Property(r => r.Rutina)
            .HasColumnName("Rutina");

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>().ToTable("Usuario");
        modelBuilder.Entity<Profesional>().ToTable("Profesionales");
        modelBuilder.Entity<Rutinas>().ToTable("Rutinas");
    }

}

