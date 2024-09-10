using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementUsingWebApi.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentResponse> AssignmentResponses { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
                                                                                                    
        }

       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasIndex(e => e.ClassId, "IX_Assignments_ClassId");

            entity.HasIndex(e => e.SubjectId, "IX_Assignments_SubjectId");

            entity.HasIndex(e => e.TeacherId, "IX_Assignments_TeacherId");

            entity.HasOne(d => d.Class).WithMany(p => p.Assignments).HasForeignKey(d => d.ClassId);

            entity.HasOne(d => d.Subject).WithMany(p => p.Assignments).HasForeignKey(d => d.SubjectId);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Assignments).HasForeignKey(d => d.TeacherId);
        });

        modelBuilder.Entity<AssignmentResponse>(entity =>
        {
            entity.HasIndex(e => e.AssignmentId, "IX_AssignmentResponses_AssignmentId");

            entity.HasIndex(e => e.StudentId, "IX_AssignmentResponses_StudentId");

            entity.HasOne(d => d.Assignment).WithMany(p => p.AssignmentResponses).HasForeignKey(d => d.AssignmentId);

            entity.HasOne(d => d.Student).WithMany(p => p.AssignmentResponses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasIndex(e => e.StudentId, "IX_Attendances_StudentId");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.AnnualFees).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<LeaveApplication>(entity =>
        {
            entity.HasIndex(e => e.TeacherId, "IX_LeaveApplications_TeacherId");

            entity.HasOne(d => d.Teacher).WithMany(p => p.LeaveApplications).HasForeignKey(d => d.TeacherId);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.ClassId, "IX_Students_ClassId");

            entity.Property(e => e.FeesStatus).HasMaxLength(50);
            entity.Property(e => e.ParentEmail).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Std).HasMaxLength(50);

            entity.HasOne(d => d.Class).WithMany(p => p.Students).HasForeignKey(d => d.ClassId);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasIndex(e => e.ClassId, "IX_Teachers_ClassId");

            entity.HasIndex(e => e.SubjectId, "IX_Teachers_SubjectId");

            entity.Property(e => e.MonthlySalary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Class).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Subject).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasIndex(e => e.ClassId, "IX_Timetables_ClassId");

            entity.HasOne(d => d.Class).WithMany(p => p.Timetables).HasForeignKey(d => d.ClassId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
