using Appointment.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Appointment.DAC
{
    public class SqlDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Models.Domain.Appointment> Appointments { get; set; }

        public virtual DbSet<Models.Domain.AppointmentStatus> AppointmentStatuses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=Appointment;Persist Security Info=False;User ID=sa2;Password=12345qwert;MultipleActiveResultSets=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUsers(modelBuilder);
            ConfigureAppointments(modelBuilder);
            ConfigureAppointmentStatuses(modelBuilder);
        }

        private static void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(c => c.UserId);
                entity.Property(c => c.UserGuid).IsRequired().HasDefaultValueSql("newid()");
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.UserTypeId).IsRequired();
                entity.Property(c => c.UserStatusId).IsRequired();
            });
        }

        private static void ConfigureAppointments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Domain.Appointment>(entity =>
            {
                entity.ToTable("Appointment");
                entity.HasKey(a => a.AppointmentId);
                entity.Property(a => a.AppointmentGuid).IsRequired().HasDefaultValueSql("newid()");
                entity.Property(a => a.Title).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Description).HasMaxLength(500);
                entity.Property(a => a.AppointmentDate).IsRequired();
                entity.Property(a => a.AppointmentStatusId).IsRequired();
                entity.Property(a => a.UserId).IsRequired();

                // Relaciones
                entity.HasOne(a => a.User)
                      .WithMany(u => u.Appointments)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.AppointmentStatus)
                      .WithMany(s => s.Appointments)
                      .HasForeignKey(a => a.AppointmentStatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureAppointmentStatuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentStatus>(entity =>
            {
                entity.ToTable("AppointmentStatus");
                entity.HasKey(c => c.AppointmentStatusId);
                entity.Property(c => c.AppointmentStatusName).IsRequired().HasMaxLength(100);
            });
        }
    }
}
