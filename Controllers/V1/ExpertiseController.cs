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
    public class ExpertiseController : Controller
    {
        private readonly IExpertiseService _ExpertiseService;
        private readonly IMapper _mapper;

        public ExpertiseController(IExpertiseService ExpertiseService, IMapper mapper)
        {
            _ExpertiseService = ExpertiseService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Expertise.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var expertises = await _ExpertiseService.GetAll();

            return Ok(_mapper.Map<List<ExpertiseResponse>>(expertises));
        }

        [HttpGet(ApiRoutes.Expertise.Get)]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var expertise = await _ExpertiseService.GetById(Id);

            if (expertise == null)
                return NotFound();

            return Ok(_mapper.Map<ExpertiseResponse>(expertise));
        }


        [HttpPost(ApiRoutes.Expertise.Create)]
        public async Task<IActionResult> Create([FromBody] CreateExpertiseRequest expertiseRequest)
        {
            var expertise = _mapper.Map<Expertise>(expertiseRequest);
            var created = await _ExpertiseService.Create(expertise);

            if (!created)
            {
                return BadRequest(new { error = "unable to create expert" });
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Expertise.Get.Replace("{Id}", expertise.Id.ToString());

            return Created(locationUrl, _mapper.Map<ExpertiseResponse>(expertise));
        }

        [HttpPut(ApiRoutes.Expertise.Update)]
        public async Task<IActionResult> Update([FromRoute]int Id, [FromBody] UpdateExpertiseRequest request)
        {

            var expertise = await _ExpertiseService.GetById(Id);
            //expert.Date = request.Date;
            //expert.Title = request.Title;
            //expert.Branch = request.Branch;
            //expert.Reagent = request.Reagent;
            //expert.UserId = request.UserId;
            //expert.Title = request.Title;

            var Updated = await _ExpertiseService.Update(expertise);

            if (Updated)
                return Ok(_mapper.Map<ExpertiseResponse>(expertise));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Expertise.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int Id)
        {

            var Deleted = await _ExpertiseService.Delete(Id);

            if (Deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPost(ApiRoutes.Expertise.GetAllExpertiseByParentId)]
        public async Task<IActionResult> GetAllExpertiseByCategoryId([FromBody] CreateExpertiseByCategoryIdRequest createExpertiseByCategoryIdRequest)
        {

            var expertises = await _ExpertiseService.GetAllExpertiseByCategoryId(createExpertiseByCategoryIdRequest);

            return Ok(_mapper.Map<List<ExpertiseResponse>>(expertises));


          
        }
        

    }
}
