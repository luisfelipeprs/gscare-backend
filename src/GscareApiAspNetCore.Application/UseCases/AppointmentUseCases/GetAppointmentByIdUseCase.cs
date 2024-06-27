using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public class GetAppointmentByIdUseCase : IGetAppointmentByIdUseCase
    {
        private readonly IAppointmentReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAppointmentByIdUseCase(IAppointmentReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseAppointmentJson> Execute(long id)
        {
            var result = await _repository.GetById(id);

            if (result is null)
            {
                throw new NotFoundException("APPOINTMENT_NOT_FOUND");
            }

            return _mapper.Map<ResponseAppointmentJson>(result);
        }
    }
}
