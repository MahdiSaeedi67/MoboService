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
    public class SearchController : Controller
    {
        private readonly ISearchService _SearchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService SearchService, IMapper mapper)
        {
            _SearchService = SearchService;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Search.search)]
        public async Task<IActionResult> Search([FromBody] FilterSearchRequest filterSearchRequest)
        {

            var results = await _SearchService.Search(filterSearchRequest);

            return Ok(_mapper.Map<List<SearchResponse>>(results));

        }
        

    }
}
