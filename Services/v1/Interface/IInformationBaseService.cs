
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Services.v1.Interface
{
    public interface IInformationBaseService
    {
        //Task<List<Branch>> BranchGetAll();
        //Task<List<Reagent>> ReagentGetAll(int branch);
        Task<List<CountyResponse>> GetAllCountyByProvinceId(SelectCountyByProvinceIdRequest selectCountyByProvinceIdRequest);
    }
}
