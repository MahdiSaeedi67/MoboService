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
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Contracts.v1.Requests.Update;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    //[Authorize]
    public class AdvertiesController : Controller
    {
        private readonly IAdvertiesService _AdvertiesService;
        private readonly IMapper _mapper;

        public AdvertiesController(IAdvertiesService AdvertiesService, IMapper mapper)
        {
            _AdvertiesService = AdvertiesService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Adverties.GetAll)]
        public async Task<IActionResult> GetAll(SelectActiveAdvertiesRequest selectActiveAdvertiesRequest)
        {
            var advertieses = await _AdvertiesService.GetAll(selectActiveAdvertiesRequest);

            return Ok(_mapper.Map<List<AdvertiesResponse>>(advertieses));
        }

        [HttpGet(ApiRoutes.Adverties.Get)]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var adverties = await _AdvertiesService.GetById(Id);

            if (adverties == null)
                return NotFound();

            return Ok(_mapper.Map<AdvertiesResponse>(adverties));
        }


        [HttpPost(ApiRoutes.Adverties.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAdvertiesRequest advertiesRequest)
        {
            var adverties = _mapper.Map<Adverties>(advertiesRequest);
            var created = await _AdvertiesService.Create(adverties);

            if (!created)
            {
                return BadRequest(new { error = "unable to create adverties" });
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Adverties.Get.Replace("{Id}", adverties.Id.ToString());

            return Created(locationUrl, _mapper.Map<AdvertiesResponse>(adverties));
        }

        [HttpPut(ApiRoutes.Adverties.Update)]
        public async Task<IActionResult> Update([FromRoute]int Id, [FromBody] UpdateAdvertiesRequest request)
        {

            var adverties = await _AdvertiesService.GetById(Id);
            //expert.Date = request.Date;
            //expert.Title = request.Title;
            //expert.Branch = request.Branch;
            //expert.Reagent = request.Reagent;
            //expert.UserId = request.UserId;
            //expert.Title = request.Title;

            var Updated = await _AdvertiesService.Update(adverties);

            if (Updated)
                return Ok(_mapper.Map<AdvertiesResponse>(adverties));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Adverties.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int Id)
        {

            var Deleted = await _AdvertiesService.Delete(Id);

            if (Deleted)
                return NoContent();

            return NotFound();
        }


    }
}
