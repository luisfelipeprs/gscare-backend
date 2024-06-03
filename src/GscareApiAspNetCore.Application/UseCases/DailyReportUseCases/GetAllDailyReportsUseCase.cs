using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public class GetAllDailyReportsUseCase : IGetAllDailyReportsUseCase
{
    private readonly IDailyReportReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllDailyReportsUseCase(IDailyReportReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseDailyReportsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseDailyReportsJson
        {
            DailyReport = _mapper.Map<List<ResponseShortDailyReportJson>>(result)
        };
    }
}
