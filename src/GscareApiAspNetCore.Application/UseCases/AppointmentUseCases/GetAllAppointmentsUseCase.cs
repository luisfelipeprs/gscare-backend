using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public class GetAllAppointmentsUseCase : IGetAllAppointmentsUseCase
    {
        private readonly IAppointmentReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAppointmentsUseCase(IAppointmentReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseAppointmentsJson> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseAppointmentsJson
            {
                Appointments = _mapper.Map<List<ResponseAppointmentJson>>(result)
            };
        }
    }
}
