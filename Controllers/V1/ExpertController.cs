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
using AppointmentService.Domain.v1;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    //[Authorize]
    public class ExpertController : Controller
    {
        private readonly IExpertService _ExpertService;
        private readonly IMapper _mapper;

        public ExpertController(IExpertService ExpertService, IMapper mapper)
        {
            _ExpertService = ExpertService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Expert.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var experts = await _ExpertService.GetAll();

            return Ok(_mapper.Map<List<ExpertResponse>>(experts));
        }

        [HttpGet(ApiRoutes.Expert.Get)]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var expert = await _ExpertService.GetById(Id);

            if (expert == null)
                return NotFound();

            return Ok(_mapper.Map<ExpertResponse>(expert));
        }


        [HttpPost(ApiRoutes.Expert.Create)]
        public async Task<IActionResult> Create([FromBody] CreateExpertRequest expertRequest)
        {
            var expert = _mapper.Map<Expert>(expertRequest);
            var created = await _ExpertService.Create(expert);

            if (!created)
            {
                return BadRequest(new { error = "unable to create expert" });
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Expert.Get.Replace("{Id}", expert.Id.ToString());

            return Created(locationUrl, _mapper.Map<ExpertResponse>(expert));
        }

        [HttpPut(ApiRoutes.Expert.Update)]
        public async Task<IActionResult> Update([FromRoute]int Id, [FromBody] UpdateExpertRequest request)
        {

            var expert = await _ExpertService.GetById(Id);
            //expert.Date = request.Date;
            //expert.Title = request.Title;
            //expert.Branch = request.Branch;
            //expert.Reagent = request.Reagent;
            //expert.UserId = request.UserId;
            //expert.Title = request.Title;

            var Updated = await _ExpertService.Update(_mapper.Map<Expert>(expert));

            if (Updated)
                return Ok(_mapper.Map<ExpertResponse>(expert));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Expert.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int Id)
        {

            var Deleted = await _ExpertService.Delete(Id);

            if (Deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPost(ApiRoutes.Expert.GetAllBetterExpert)]
        public async Task<IActionResult> GetAllBetterExpertise([FromBody] CreateBetterExpertRequest createBetterExpertRequest)
        {

            var experts = await _ExpertService.GetAllBetterExpertise(createBetterExpertRequest);

            return Ok(_mapper.Map<List<ExpertResponse>>(experts));
          
        }

        [HttpPost(ApiRoutes.Expert.GetExpertsByExpertiseId)]
        public async Task<IActionResult> GetExpertsByExpertiseId([FromBody] SelectExpertByExpertiseIdRequest selectExpertByExpertiseIdRequest)
        {

            var experts = await _ExpertService.GetExpertsByExpertiseId(selectExpertByExpertiseIdRequest);

            return Ok(_mapper.Map<List<ExpertResponse>>(experts));

        }


    }
}
