using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public class GetDailyReportByIdUseCase : IGetDailyReportByIdUseCase
{
    private readonly IDailyReportReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetDailyReportByIdUseCase(IDailyReportReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseDailyReportJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseDailyReportJson>(result);
    }
}
