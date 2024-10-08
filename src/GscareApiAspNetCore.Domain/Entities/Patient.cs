﻿namespace GscareApiAspNetCore.Domain.Entities;
public class Patient
{
    public long Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Patologia { get; set; } = string.Empty;
    public string EnderecoDeAtendimentoComCep { get; set; } = string.Empty;
    public string NomeCompletoDoResponsavelFinanceiro { get; set; } = string.Empty;
    public string DataDePagamento { get; set; } = string.Empty;
    public string FormaDePagamento { get; set; } = string.Empty;
    public string GrauDeParentesco { get; set; } = string.Empty;
    public string Identidade { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public long? CurrentCompanyId { get; set; }
    public Company? CurrentCompany { get; set; }
    public User? User { get; set; }

    // Adicionar esta propriedade
    public ICollection<Supply> Supplies { get; set; } = new List<Supply>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();


}
