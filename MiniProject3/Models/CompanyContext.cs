using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiniProject3.Models;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Workson> Worksons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("departments_pkey");

            entity.HasOne(d => d.MgrempnoNavigation).WithMany(p => p.Departments).HasConstraintName("departments_mgrempno_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("employees_pkey");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Employees).HasConstraintName("fk_deptno");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projno).HasName("projects_pkey");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Projects).HasConstraintName("projects_deptno_fkey");
        });

        modelBuilder.Entity<Workson>(entity =>
        {
            entity.HasKey(e => new { e.Empno, e.Projno }).HasName("workson_pkey");

            entity.HasOne(d => d.EmpnoNavigation).WithMany(p => p.Worksons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workson_empno_fkey");

            entity.HasOne(d => d.ProjnoNavigation).WithMany(p => p.Worksons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("workson_projno_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
