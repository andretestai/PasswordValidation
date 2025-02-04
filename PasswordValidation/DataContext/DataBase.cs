using Microsoft.EntityFrameworkCore;
using PasswordValidation.Models;

public class DataBase : DbContext
{
    public DataBase(DbContextOptions<DataBase> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuarios");

            entity.Property(u => u.NomeUsuario)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            entity.Property(u => u.SenhaUsuario)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
        });
    }
}

