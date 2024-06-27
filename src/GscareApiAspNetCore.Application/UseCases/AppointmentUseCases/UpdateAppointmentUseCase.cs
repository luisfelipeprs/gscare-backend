using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public class UpdateAppointmentUseCase : IUpdateAppointmentUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentUpdateOnlyRepository _repository;

        public UpdateAppointmentUseCase(IMapper mapper, IUnitOfWork unitOfWork, IAppointmentUpdateOnlyRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Execute(long id, RequestAppointmentJson request)
        {
            Validate(request);

            var appointment = await _repository.GetById(id);

            if (appointment is null)
            {
                throw new NotFoundException("APPOINTMENT_NOT_FOUND");
            }

            // Map the incoming request data to the existing appointment entity
            _mapper.Map(request, appointment);

            // Update the appointment in the repository
            _repository.Update(appointment);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestAppointmentJson request)
        {
            var validator = new AppointmentValidator(); // Implement AppointmentValidator similarly to CompanyValidator

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
