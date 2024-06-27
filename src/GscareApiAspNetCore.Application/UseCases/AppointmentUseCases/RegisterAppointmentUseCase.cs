using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public class RegisterAppointmentUseCase : IRegisterAppointmentUseCase
    {
        private readonly IAppointmentWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterAppointmentUseCase(IAppointmentWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisteredAppointmentJson> Execute(RequestAppointmentJson request)
        {
            Validate(request);

            var entity = _mapper.Map<Appointment>(request);

            await _repository.Add(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisteredAppointmentJson>(entity);
        }

        private void Validate(RequestAppointmentJson request)
        {
            // Implement validation logic here if needed
        }
    }
}
