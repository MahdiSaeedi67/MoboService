
using AppointmentService.Contracts.v1.Requests.Filter;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Services.v1.Interface
{
    public interface ISearchCityService
    {
        Task<List<SearchCityResponse>> Search(FilterSearchCityRequest filterSearchCityRequest);

    }
}
