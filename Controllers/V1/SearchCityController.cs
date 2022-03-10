using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Services.v1.Interface;
using AppointmentService.Contracts.v1;
using AppointmentService.Contracts.v1.Requests.Filter;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    //[Authorize]
    public class SearchCityController : Controller
    {
        private readonly ISearchCityService _SearchCityService;
        private readonly IMapper _mapper;

        public SearchCityController(ISearchCityService SearchCityService, IMapper mapper)
        {
            _SearchCityService = SearchCityService;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Search.searchCity)]
        public async Task<IActionResult> Search([FromBody] FilterSearchCityRequest filterSearchCityRequest)
        {

            var results = await _SearchCityService.Search(filterSearchCityRequest);

            return Ok(_mapper.Map<List<SearchCityResponse>>(results));

        }
        

    }
}
