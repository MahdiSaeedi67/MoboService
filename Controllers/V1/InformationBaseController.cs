using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppointmentService.Contracts.v1.Requests;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Services;
using AppointmentService.Services.v1.Interface;
using AppointmentService.Contracts.v1;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Update;
using AppointmentService.Domain;
using Microsoft.AspNetCore.Authorization;
using AppointmentService.Contracts.v1.Requests.Select;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    //[Authorize]
    public class InformationBaseController : Controller
    {
        private readonly IInformationBaseService _InformationBaseService;
        private readonly IMapper _mapper;

        public InformationBaseController(IInformationBaseService InformationBaseService, IMapper mapper)
        {
            _InformationBaseService = InformationBaseService;
            _mapper = mapper;
        }

        //[HttpGet(ApiRoutes.InformationBase.BranchGetAll)]
        //public async Task<IActionResult> BranchGetAll()
        //{
        //    var branches = await _InformationBaseService.BranchGetAll();
        //    return Ok(_mapper.Map<List<BranchResponse>>(branches));
        //}

        //[HttpGet(ApiRoutes.InformationBase.ReagentGetAll)]
        //public async Task<IActionResult> ReagentGetAll([FromRoute]int branch)
        //{
        //    var reagents = await _InformationBaseService.ReagentGetAll(branch);
        //    return Ok(_mapper.Map<List<ReagentResponse>>(reagents));
        //}

        //[HttpGet(ApiRoutes.InformationBase.MeetingTypeGetAll)]
        //public async Task<IActionResult> MeetingTypeGetAll()
        //{
        //    var meetingTypes = await _InformationBaseService.MeetingTypeGetAll();
        //    return Ok(_mapper.Map<List<MeetingTypeResponse>>(meetingTypes));
        //}

        [HttpPost(ApiRoutes.InformationBase.GetAllGetAllCountyByProvinceId)]
        public async Task<IActionResult> Search([FromBody] SelectCountyByProvinceIdRequest selectCountyByProvinceIdRequest)
        {

            var results = await _InformationBaseService.GetAllCountyByProvinceId(selectCountyByProvinceIdRequest);

            return Ok(_mapper.Map<List<CountyResponse>>(results));

        }

    }
}
