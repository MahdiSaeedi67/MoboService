using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppointmentService.Contracts.v1.Requests.Filter;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Services;
using AppointmentService.Services.v1.Interface;
using AppointmentService.Contracts.v1;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Update;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using Microsoft.AspNetCore.Authorization;
using AppointmentService.Domain.v1.UserDefenition;
using AppointmentService.Contracts.v1.Requests.Select;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IAuthenticationManagerService authenticationManagerService;

        public AccountController(IAuthenticationManagerService authenticationManagerService, IMapper mapper)
        {
            this.authenticationManagerService = authenticationManagerService;
            _mapper = mapper;
        }


        [HttpGet("Get")]
        public string GetAuthorizState()
        {
            return "Authorized";
        }


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.Authenticate)]
        public IActionResult Authenticate([FromBody] LoginRequest loginRequest)
        {
            var login = authenticationManagerService.Authenticate(loginRequest);

            if (login == null)
                return Unauthorized();

            return Ok(login);
        }

        [HttpGet(ApiRoutes.Account.CurrentUser)]
        public User CurrentUser()
        {
            return authenticationManagerService.GetCurrentUser();
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.RegisterOTP)]
        public async Task<IActionResult> Create([FromBody] GetOTPRequest getOTPRequest)
        {
            var otp = await authenticationManagerService.GetOTP(getOTPRequest);

            if (otp==null)
            {
                return BadRequest(new { error = "unable to create OTP" });
            }
            return Ok(_mapper.Map<OTPSResponse>(otp));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.IsRegistered)]
        public bool IsRegistered([FromBody] string mobile)
        {
            return authenticationManagerService.isRegistered(mobile);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.Register)]
        public IActionResult Create([FromBody] CreateRegisterRequest createRegisterRequest)
        {
            
            var login = authenticationManagerService.Register(createRegisterRequest);

            if (login == null)
                return Unauthorized();

            return Ok(login);
            
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.UpdatePassword)]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest updatePasswordRequest)
        {

            var updated = await authenticationManagerService.UpdatePassword(updatePasswordRequest);

            if (!updated)
            {
                return BadRequest(new { error = "unable to update password" });
            }

            return Ok(updated);
        }


    }
}
