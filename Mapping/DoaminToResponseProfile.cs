using AutoMapper;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Mapping
{
    public class DoaminToResponseProfile:Profile
    {
        public DoaminToResponseProfile()
        {
            
            CreateMap<Expert, ExpertResponse>();
            CreateMap<Expertise, ExpertiseResponse>();
            CreateMap<Branch, BranchResponse>();
            CreateMap<Reagent, ReagentResponse>();
            CreateMap<Appointment, AppointmentResponse>();
            CreateMap<AppointmentDate, AppointmentDateResponse>();
            CreateMap<AppointmentTime, AppointmentTimeResponse>();
            CreateMap<OTPS, OTPSResponse>();
            CreateMap<SearchReason, SearchResponse>();

        }
    }
}
