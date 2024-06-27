using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public class DeleteAppointmentUseCase : IDeleteAppointmentUseCase
    {
        private readonly IAppointmentWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAppointmentUseCase(IAppointmentWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var result = await _repository.Delete(id);

            if (!result)
            {
                throw new NotFoundException("APPOINTMENT_NOT_FOUND");
            }

            await _unitOfWork.Commit();
        }
    }
}
