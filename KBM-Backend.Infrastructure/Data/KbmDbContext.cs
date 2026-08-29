using KBM_Backend.Application.Interfaces;
using KBM_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KBM_Backend.Infrastructure.Data;

public class KbmDbContext : DbContext, IKbmDbContext
{
    public KbmDbContext(DbContextOptions<KbmDbContext> options)
        : base(options)
    {
    }

    public DbSet<Function> Functions { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Industry> Industries { get; set; }

    public DbSet<Lesson> Lessons { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<DepartmentFunction> DepartmentFunctions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Function>(entity =>
        {
            entity.ToTable("Functions");

            entity.HasKey(f => f.Id);

            entity.Property(f => f.Id)
                .ValueGeneratedNever();

            entity.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(f => f.CreatedDate)
                .IsRequired();

            entity.Property(f => f.ModifiedDate)
                .IsRequired();
        });


        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Departments");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id)
                .ValueGeneratedNever();

            entity.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(d => d.CreatedDate)
                .IsRequired();

            entity.Property(d => d.ModifiedDate)
                .IsRequired();
        });


        modelBuilder.Entity<Industry>(entity =>
        {
            entity.ToTable("Industries");

            entity.HasKey(i => i.Id);

            entity.Property(i => i.Id)
                .ValueGeneratedNever();

            entity.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(i => i.CreatedDate)
                .IsRequired();

            entity.Property(i => i.ModifiedDate)
                .IsRequired();
        });


        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lessons");

            entity.HasKey(l => l.Id);

            entity.Property(l => l.Id)
                .ValueGeneratedNever();

            entity.Property(l => l.Title)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(l => l.ProjectName)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(l => l.ValueProposition)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(l => l.Description)
                .HasColumnType("nvarchar(max)");

            entity.Property(l => l.ImageUrl)
                .HasMaxLength(500);

            entity.Property(l => l.PersonToContact)
                .HasMaxLength(250);

            entity.Property(l => l.CreatedDate)
                .IsRequired();

            entity.Property(l => l.ModifiedDate)
                .IsRequired();

            // Department -> Lessons
            entity.HasOne(l => l.Department)
                .WithMany(d => d.Lessons)
                .HasForeignKey(l => l.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Function -> Lessons
            entity.HasOne(l => l.Function)
                .WithMany(f => f.Lessons)
                .HasForeignKey(l => l.FunctionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Industry -> Lessons
            entity.HasOne(l => l.Industry)
                .WithMany(i => i.Lessons)
                .HasForeignKey(l => l.IndustryId)
                .OnDelete(DeleteBehavior.Restrict);
        });


        modelBuilder.Entity<DepartmentFunction>(entity =>
        {
            entity.ToTable("DepartmentFunctions");

            // Composite Primary Key
            entity.HasKey(df => new
            {
                df.DepartmentId,
                df.FunctionId
            });

            // Department -> DepartmentFunctions
            entity.HasOne(df => df.Department)
                .WithMany(d => d.DepartmentFunctions)
                .HasForeignKey(df => df.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Function -> DepartmentFunctions
            entity.HasOne(df => df.Function)
                .WithMany(f => f.DepartmentFunctions)
                .HasForeignKey(df => df.FunctionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                .ValueGeneratedNever();

            entity.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(u => u.CreatedDate)
                .IsRequired();

            entity.Property(u => u.ModifiedDate)
                .IsRequired();

            entity.HasIndex(u => u.Username)
                .IsUnique();

            entity.HasIndex(u => u.Email)
                .IsUnique();
        });
    }
}