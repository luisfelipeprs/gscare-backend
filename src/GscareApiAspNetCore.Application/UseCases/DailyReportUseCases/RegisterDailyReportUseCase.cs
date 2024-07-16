using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public class RegisterDailyReportUseCase : IRegisterDailyReportUseCase
{
    private readonly IDailyReportWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterDailyReportUseCase(
        IDailyReportWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredDailyReportJson> Execute(RequestDailyReportJson request)
    {
        Validate(request);

        var entity = _mapper.Map<DailyReport>(request);
        entity.AppointmentId = request.AppointmentId;

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredDailyReportJson>(entity);

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
