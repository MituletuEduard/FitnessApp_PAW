using FitnessApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Utilizator> Utilizatori { get; set; }
    public DbSet<Masuratori> Masuratori { get; set; }
    public DbSet<Antrenament> Antrenament { get; set; } = default!;
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<FitnessApp.Models.Timer> Timers { get; set; }  // Adăugat aici
    public DbSet<Exercise> Exercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser>(b =>
        {
            b.ToTable("Users");
        });

        modelBuilder.Entity<IdentityRole>(b =>
        {
            b.ToTable("Roles");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("UserRoles");
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("UserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.ToTable("UserLogins");
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
        {
            b.ToTable("RoleClaims");
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("UserTokens");
        });

        modelBuilder.Entity<Utilizator>()
            .HasOne(u => u.Masuratori)
            .WithOne(m => m.Utilizator)
            .HasForeignKey<Masuratori>(m => m.ID_Utilizator);

        modelBuilder.Entity<Antrenament>()
            .HasOne(a => a.Istoric)
            .WithOne(i => i.Antrenament)
            .HasForeignKey<Istoric>(i => i.ID_Antrenament);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserId);

        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId);
    }
}
