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
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Update;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    //[Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _AppointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService AppointmentService, IMapper mapper)
        {
            _AppointmentService = AppointmentService;
            _mapper = mapper;
        }

        //[HttpGet(ApiRoutes.Appointment.GetAll)]
        //public async Task<IActionResult> GetAll()
        //{
        //    var appointments = await _AppointmentService.GetAll();

        //    return Ok(_mapper.Map<List<AppointmentResponse>>(appointments));
        //}

        [HttpGet(ApiRoutes.Appointment.Get)]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var appointment = await _AppointmentService.GetById(Id);

            if (appointment == null)
                return NotFound();

            return Ok(_mapper.Map<AppointmentResponse>(appointment));
        }


        [HttpPost(ApiRoutes.Appointment.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentRequest createAppointmentRequest)
        {
            //var appointment = _mapper.Map<Appointment>(appointmentRequest);
            var created = await _AppointmentService.Create(createAppointmentRequest);

            if (!created)
            {
                return BadRequest(new { error = "unable to create appointment" });
            }

            // var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            // var locationUrl = baseUrl + "/" + ApiRoutes.Appointment.Get.Replace("{Id}", appointment.Id.ToString());

            //return Created(locationUrl, _mapper.Map<AppointmentResponse>(appointment));
            return Ok(created);
        }

        [HttpPut(ApiRoutes.Appointment.Update)]
        public async Task<IActionResult> Update([FromRoute]int Id, [FromBody] UpdateAppointmentRequest request)
        {

            var appointment = await _AppointmentService.GetById(Id);
            //expert.Date = request.Date;
            //expert.Title = request.Title;
            //expert.Branch = request.Branch;
            //expert.Reagent = request.Reagent;
            //expert.UserId = request.UserId;
            //expert.Title = request.Title;

            var Updated = await _AppointmentService.Update(_mapper.Map<Appointment>(appointment));

            if (Updated)
                return Ok(_mapper.Map<AppointmentResponse>(appointment));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Appointment.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int Id)
        {

            var Deleted = await _AppointmentService.Delete(Id);

            if (Deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPost(ApiRoutes.Appointment.GetFreeAppointmentDateByExpertID)]
        public async Task<IActionResult> GetFreeAppointmentDateByExpertID([FromBody] SelectFreeAppointmentDateByExpertIdRequest selectFreeAppointmentDateByExpertIdRequest)
        {

            var dates = await _AppointmentService.GetFreeAppointmentDateByExpertID(selectFreeAppointmentDateByExpertIdRequest);

            return Ok(_mapper.Map<List<AppointmentDateResponse>>(dates));

        }

        [HttpPost(ApiRoutes.Appointment.GetAppointmentTimeByExpertID)]
        public async Task<IActionResult> GetAppointmentTimeByExpertID([FromBody] SelectAppointmentTimeByExpertIdRequest selectAppointmentTimeByExpertIdRequest)
        {

            var times = await _AppointmentService.GetAppointmentTimesByExpertID(selectAppointmentTimeByExpertIdRequest);

            return Ok(_mapper.Map<List<AppointmentTimeResponse>>(times));

        }

        [HttpPost(ApiRoutes.Appointment.GetAppointmentTypeByExpertID)]
        public async Task<IActionResult> GetAppointmentTypeByExpertID([FromBody] SelectAppointmentTypeByExpertIdRequest selectAppointmentTypeByExpertIdRequest)
        {

            var types = await _AppointmentService.GetAppointmentTypeByExpertID(selectAppointmentTypeByExpertIdRequest);

            return Ok(_mapper.Map<List<AppointmentTypeResponse>>(types));

        }

        [HttpPost(ApiRoutes.Appointment.GetAppointmentByCustomerID)]
        public async Task<IActionResult> GetAppointmentByCustomerID([FromBody] SelectAppointmentByCustomerIdRequest selectAppointmentByCustomerIdRequest)
        {

            var appointments = await _AppointmentService.GetAppointmentByCustomerID(selectAppointmentByCustomerIdRequest);

            return Ok(_mapper.Map<List<AppointmentResponse>>(appointments));

        }

        [HttpPost(ApiRoutes.Appointment.SetAppointment)]
        public async Task<IActionResult> setAppointment([FromBody] UpdateSetAppointmentRequest updateSetAppointmentRequest)
        {

            bool Updated =await _AppointmentService.SetAppointment(updateSetAppointmentRequest);
            
            if (Updated)
                return Ok(Updated);

            return NotFound();
        }
    }
}
