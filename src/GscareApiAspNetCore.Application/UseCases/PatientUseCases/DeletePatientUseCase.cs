using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.PatientRepositories;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public class DeletePatientUseCase : IDeletePatientUseCase
{
    private readonly IPatientWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePatientUseCase(IPatientWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException("Patient not found.");
        }

        await _unitOfWork.Commit();
    }
}
