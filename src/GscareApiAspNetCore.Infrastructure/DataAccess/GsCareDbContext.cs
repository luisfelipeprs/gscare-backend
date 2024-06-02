using GscareApiAspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess;
internal class GsCareDbContext: DbContext
{
    public GsCareDbContext(DbContextOptions options): base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Warning> Warnings { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Supply> Supplies { get; set; }


    // Monitoramento de suprimentos de consumo (papel, fralda e etc....) [x]

    // Calendario
    // public DbSet<Agendamentos>
    // -> agendamentos

    // Perfil [update user] 

    // Relatório diário e eventos inesperados


    // Comunicacao direta e feedback
    // Gestão de documentos do paciente

}
