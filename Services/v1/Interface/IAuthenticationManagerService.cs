
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.Contracts.v1.Requests.Filter;
using AppointmentService.Data;
using AppointmentService.Options;
using AppointmentService.Domain.v1.UserDefenition;
using AppointmentService.Domain;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Select;

namespace AppointmentService.Services.v1.Interface
{
    public interface IAuthenticationManagerService
    {
        Login Authenticate(LoginRequest loginRequest);
        User GetCurrentUser();
        Task<OTPSResponse> GetOTP(GetOTPRequest getOTPRequest);
        //bool HasActiveOTP(GetOTPRequest getOTPRequest);
        Login Register(CreateRegisterRequest createRegisterRequest);
        Task<bool> UpdatePassword(UpdatePasswordRequest updatePasswordRequest);
        bool isRegistered(string mobile);
    }
}
