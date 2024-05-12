using Bogus;
using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Communication.Requests;
namespace CommonTestUtils.Requests;
public class RequestRegisterEmployeeJsonBuilder
{
    public static RequestRegisterEmployeeJson Build()
    {
        //var faker = new Faker();

        //var request = new RequestRegisterEmployeeJson
        //{
        //    NomeCompleto = faker.Name.FullName(),
        //};

        return new Faker<RequestRegisterEmployeeJson>()
            .RuleFor(r => r.NomeCompleto, faker => faker.Name.FullName())
            .RuleFor(r => r.DisponibilidadeDeHorario, faker => faker.PickRandom<DisponibilidadeDeHorarioType>())
            .RuleFor(r => r.CertificadoDoCurso, faker => faker.Address.CountryCode())
            .RuleFor(r => r.Cpf, faker => faker.Company.CompanyName())
            .RuleFor(r => r.EnderecoComCep, faker => faker.Company.CompanyName())
            .RuleFor(r => r.FotoComprovanteResidencia, faker => faker.Company.CompanyName())
            .RuleFor(r => r.FotoCpf, faker => faker.Company.CompanyName())
            .RuleFor(r => r.FotoIdentidade, faker => faker.Company.CompanyName())
            .RuleFor(r => r.Identidade, faker => faker.Company.CompanyName())
            .RuleFor(r => r.Mei, faker => faker.Company.CompanyName())
            .RuleFor(r => r.NadaConsta, faker => faker.Company.CompanyName());

        //{
        //    NomeCompleto = "fernando franco",
        //    DisponibilidadeDeHorario = 0,
        //    CertificadoDoCurso = "",
        //    Cpf = "",
        //    EnderecoComCep = "",
        //    FotoComprovanteResidencia = "",
        //    FotoCpf = "",
        //    FotoIdentidade = "",
        //    Identidade = "",
        //    Mei = "",
        //    NadaConsta = ""
        //};
    }
}
