using AutoMapper;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases.CompanyUseCases;
public class GetCompanyByIdUseCase : IGetCompanyByIdUseCase
{
    private readonly ICompanyReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetCompanyByIdUseCase(ICompanyReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseCompanyJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
        }

        return _mapper.Map<ResponseCompanyJson>(result);
    }
}
