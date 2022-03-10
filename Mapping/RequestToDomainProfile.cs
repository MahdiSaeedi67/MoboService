using AutoMapper;
using AppointmentService.Contracts.v1.Requests;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AppointmentService.Mapping
{
    public class RequestToDomainProfile:Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateExpertRequest,Expert>();
            CreateMap<CreateExpertiseRequest, Expertise>();
            CreateMap<SelectActiveAdvertiesRequest, Adverties>();
            CreateMap<SelectFreeAppointmentDateByExpertIdRequest, AppointmentDate>();
            CreateMap<SelectAppointmentTimeByExpertIdRequest, AppointmentTime>();
            CreateMap<CreateRegisterRequest, Users>();


        }

    }
}
