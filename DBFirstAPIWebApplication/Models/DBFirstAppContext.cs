using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstAPIWebApplication.Models
{
    public partial class DBFirstAppContext : DbContext
    {
        public DBFirstAppContext()
        {
        }

        public DBFirstAppContext(DbContextOptions<DBFirstAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DBFirstApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId);

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("deptId");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("deptName");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudId);

                entity.ToTable("student");

                entity.Property(e => e.StudId).ValueGeneratedNever();

                entity.Property(e => e.DepartId).HasColumnName("departId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartId)
                    .HasConstraintName("FK_student_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
