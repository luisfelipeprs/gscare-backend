using Bogus;
using Bogus.Extensions.Brazil;
using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Communication.Requests;
namespace CommonTestUtils.Requests;
public class RequestRegisterEmployeeJsonBuilder
{
    public static RequestEmployeeJson Build()
    {

        return new Faker<RequestEmployeeJson>()
            .RuleFor(r => r.NomeCompleto, faker => faker.Name.FullName())
            .RuleFor(r => r.DisponibilidadeDeHorario, faker => faker.PickRandom<DisponibilidadeDeHorarioType>())
            .RuleFor(r => r.CertificadoDoCurso, faker => faker.Address.CountryCode())
            .RuleFor(r => r.Cpf, faker => faker.Person.Cpf())
            .RuleFor(r => r.EnderecoComCep, faker => faker.Address.FullAddress())
            .RuleFor(r => r.FotoComprovanteResidencia, faker => faker.Image.PicsumUrl())
            .RuleFor(r => r.FotoCpf, faker => faker.Image.PicsumUrl())
            .RuleFor(r => r.FotoIdentidade, faker => faker.Image.PicsumUrl())
            .RuleFor(r => r.Identidade, faker => faker.Random.AlphaNumeric(10))
            .RuleFor(r => r.Mei, faker => faker.Company.CompanyName())
            .RuleFor(r => r.NadaConsta, faker => faker.Lorem.Sentence());
    }
}
