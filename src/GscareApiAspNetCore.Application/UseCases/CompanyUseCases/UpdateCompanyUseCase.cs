using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
internal class UpdateCompanyUseCase : IUpdateCompanyUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyUpdateOnlyRepository _repository;

    public UpdateCompanyUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICompanyUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long Id, RequestCompanyJson request)
    {
        Validate(request);

        var company = await _repository.GetById(Id);

        if (company is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        // pega os dados da request e insere dentro do objeto => company(ja criado)
        _mapper.Map(request, company);

        _repository.Update(company);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestCompanyJson request)
    {
        var validator = new CompanyValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
