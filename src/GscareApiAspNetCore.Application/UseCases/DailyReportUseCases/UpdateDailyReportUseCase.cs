using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public class UpdateDailyReportUseCase : IUpdateDailyReportUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDailyReportUpdateOnlyRepository _repository;

    public UpdateDailyReportUseCase(IMapper mapper, IUnitOfWork unitOfWork, IDailyReportUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestDailyReportJson request)
    {
        Validate(request);

        var dailyReport = await _repository.GetById(Id);

        if (dailyReport is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        _mapper.Map(request, dailyReport);

        _repository.Update(dailyReport);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestDailyReportJson request)
    {
        var validator = new DailyReportValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
