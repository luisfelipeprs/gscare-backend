using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;
using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;
using GscareApiAspNetCore.Communication.Responses.PatientResponses;
using GscareApiAspNetCore.Communication.Responses.ServiceReponses;
using GscareApiAspNetCore.Communication.Responses.StockResponses;
using GscareApiAspNetCore.Communication.Responses.SupplyResponses;
using GscareApiAspNetCore.Communication.Responses.UserResponses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestUserJson, User>()
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<RequestAppointmentJson, Appointment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
           
            CreateMap<RequestEmployeeJson, Employee>();
            CreateMap<RequestPatientJson, Patient>();
            CreateMap<RequestCompanyJson, Company>();
            CreateMap<RequestWarningJson, Warning>();
            CreateMap<RequestMedicamentJson, Medicament>();
            CreateMap<RequestSupplyJson, Supply>();
            CreateMap<RequestStockJson, Stock>();
            CreateMap<RequestServiceJson, Service>();
            CreateMap<RequestDailyReportJson, DailyReport>();
            CreateMap<RequestAppointmentJson, Appointment>();
        }

        private void EntityToResponse()
        {
            CreateMap<User, ResponseUserProfileJson>()
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<Employee, ResponseEmployeeJson>()
                .ForMember(dest => dest.CurrentCompanyId, opt => opt.MapFrom(src => src.CurrentCompany));

            CreateMap<Patient, ResponsePatientJson>()
                .ForMember(dest => dest.CurrentCompanyId, opt => opt.MapFrom(src => src.CurrentCompany));

            CreateMap<Company, ResponseCompanyJson>();

            CreateMap<Appointment, ResponseRegisteredAppointmentJson>();
            CreateMap<Appointment, ResponseAppointmentJson>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.NomeCompleto))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.NomeCompleto));
            CreateMap<List<Appointment>, ResponseAppointmentsJson>()
                .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src));

            // DailyReport
            CreateMap<DailyReport, ResponseRegisteredDailyReportJson>();
            CreateMap<DailyReport, ResponseShortDailyReportJson>();
            CreateMap<DailyReport, ResponseDailyReportJson>();

            // Service
            CreateMap<Service, ResponseRegisteredServiceJson>();
            CreateMap<Service, ResponseShortServiceJson>();
            CreateMap<Service, ResponseServiceJson>();

            // Supply 
            CreateMap<Supply, ResponseRegisteredSupplyJson>();
            CreateMap<Supply, ResponseShortSupplyJson>();
            CreateMap<Supply, ResponseSupplyJson>();

            // Stock  
            CreateMap<Stock, ResponseRegisteredStockJson>();
            CreateMap<Stock, ResponseShortStockJson>();
            CreateMap<Stock, ResponseStockJson>();

            // Medicament 
            CreateMap<Medicament, ResponseRegisteredMedicamentJson>();
            CreateMap<Medicament, ResponseShortMedicamentJson>();
            CreateMap<Medicament, ResponseMedicamentJson>();

            // Warning 
            CreateMap<Warning, ResponseRegisteredWarningJson>();
            CreateMap<Warning, ResponseShortWarningJson>();
            CreateMap<Warning, ResponseWarningJson>();

            // Company 
            CreateMap<Company, ResponseRegisteredCompanyJson>();
            CreateMap<Company, ResponseShortCompanyJson>();
            CreateMap<Company, ResponseCompanyJson>();

            // Patient 
            CreateMap<Patient, ResponseRegisteredPatientJson>();
            CreateMap<Patient, ResponseShortPatientJson>();
            CreateMap<Patient, ResponsePatientJson>();

            // Employee
            CreateMap<Employee, ResponseRegisteredEmployeeJson>();
            CreateMap<Employee, ResponseShortEmployeeJson>();
            CreateMap<Employee, ResponseEmployeeJson>();

            // User
            CreateMap<User, ResponseRegisteredUserJson>();
            CreateMap<User, ResponseShortUserJson>();
            CreateMap<User, ResponseUserJson>();
            CreateMap<User, ResponseUserProfileJson>();
        }
    }
}
