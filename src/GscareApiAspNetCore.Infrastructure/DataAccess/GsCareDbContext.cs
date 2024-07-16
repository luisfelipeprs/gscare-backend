using GscareApiAspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess
{
    internal class GsCareDbContext : DbContext
    {
        public GsCareDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Warning> Warnings { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<User>(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.CurrentCompany)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CurrentCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.CurrentCompany)
                .WithMany(c => c.Patients)
                .HasForeignKey(p => p.CurrentCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Appointments)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Company)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Warning>()
                .HasOne(w => w.Company)
                .WithMany(c => c.Warnings)
                .HasForeignKey(w => w.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Supply>()
                .HasOne(s => s.Patient)
                .WithMany(p => p.Supplies)
                .HasForeignKey(s => s.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração para relacionar Medicaments e Patients
            modelBuilder.Entity<Medicament>()
                .HasOne(m => m.Patient)
                .WithMany(p => p.Medicaments)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Company)
                .WithMany(c => c.Stocks)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DailyReport>()
                .HasOne(dr => dr.Appointment)
                .WithMany(a => a.DailyReports)
                .HasForeignKey(dr => dr.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
