
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppointmentService.Services.v1.Interface;
using AppointmentService.Contracts.v1;
using AppointmentService.Contracts.v1.Requests.Create;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentService.Controllers.v1
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUserManagmentService userManagmentService;

        public UserController(IUserManagmentService userManagmentService, IMapper mapper)
        {
            this.userManagmentService = userManagmentService;
            _mapper = mapper;
        }

        
        [AllowAnonymous]
        [HttpPost(ApiRoutes.User.UpdateUserInformation)]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UpdateUserInformationRequest updateUserInformationRequest)
        {

            var updated = await userManagmentService.UpdateUserInformation(updateUserInformationRequest);

            if (!updated)
            {
                return BadRequest(new { error = "unable to update UserInformation" });
            }

            return Ok(updated);
        }

    }
}
