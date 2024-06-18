Para recuperar dados com relacionamentos usando o Entity Framework Core, é importante seguir algumas práticas e entender como as entidades estão configuradas no seu contexto de banco de dados (`GsCareDbContext`). Com base nas classes e configurações que você forneceu, aqui estão os passos principais para recuperar dados com relacionamentos:

### 1. Configuração do Contexto (`GsCareDbContext`)

Certifique-se de que seu contexto (`GsCareDbContext`) está configurado corretamente com todas as entidades e seus respectivos relacionamentos. O código que você forneceu parece estar bem configurado para os relacionamentos que você descreveu (por exemplo, entre `Company` e `Employee`, `Patient`, `Supply`, etc.).

### 2. Consultas com `Include` para Carregar Dados Relacionados

Para carregar entidades relacionadas ao recuperar dados, você deve usar o método `Include` do Entity Framework Core. Aqui estão alguns exemplos de como você pode fazer isso:

#### Exemplo 1: Carregar uma Empresa com Funcionários

```csharp
public async Task<Company> GetCompanyWithEmployees(long companyId)
{
    return await _context.Companies
        .Include(c => c.Employees)
        .FirstOrDefaultAsync(c => c.Id == companyId);
}
```

Neste exemplo, `Include(c => c.Employees)` carrega todos os funcionários associados à empresa especificada.

#### Exemplo 2: Carregar um Paciente com Documentos

```csharp
public async Task<Patient> GetPatientWithDocuments(long patientId)
{
    return await _context.Patients
        .Include(p => p.Documents)
        .FirstOrDefaultAsync(p => p.Id == patientId);
}
```

Aqui, `Include(p => p.Documents)` carrega todos os documentos associados ao paciente especificado.

#### Exemplo 3: Carregar um Relatório Diário com Paciente e Funcionário

```csharp
public async Task<DailyReport> GetDailyReportWithPatientAndEmployee(long dailyReportId)
{
    return await _context.DailyReports
        .Include(dr => dr.Patient)
        .Include(dr => dr.Employee)
        .FirstOrDefaultAsync(dr => dr.Id == dailyReportId);
}
```

Neste caso, `Include(dr => dr.Patient)` e `Include(dr => dr.Employee)` são usados para carregar o paciente e o funcionário associados ao relatório diário especificado.

### 3. Executando Consultas

Você pode chamar esses métodos em seus controladores ou serviços, dependendo da arquitetura da sua aplicação. Aqui está um exemplo de como você pode usá-los em um controlador:

```csharp
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly GsCareDbContext _context;

    public CompanyController(GsCareDbContext context)
    {
        _context = context;
    }

    [HttpGet("{companyId}")]
    public async Task<ActionResult<Company>> GetCompany(long companyId)
    {
        var company = await _context.Companies
            .Include(c => c.Employees)
            .FirstOrDefaultAsync(c => c.Id == companyId);

        if (company == null)
        {
            return NotFound();
        }

        return company;
    }
}
```

### Considerações Finais

Certifique-se de que seu banco de dados está configurado corretamente, com as migrações executadas conforme necessário. Você também pode usar a FluentMigrator para gerenciar suas migrações, como você já implementou.

Além disso, ao utilizar o Entity Framework Core com relacionamentos, é importante estar ciente do comportamento de carregamento preguiçoso (`Lazy Loading`) versus carregamento explícito (`Eager Loading`) usando `Include`. O carregamento explícito (`Include`) é geralmente preferido para evitar problemas de N+1, onde várias consultas adicionais podem ser disparadas inadvertidamente.

Com essas práticas, você deve conseguir recuperar dados com os relacionamentos especificados em suas entidades de forma eficiente usando o Entity Framework Core.