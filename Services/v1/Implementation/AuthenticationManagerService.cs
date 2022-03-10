using System;
using System.Collections.Generic;

using AppointmentService.Services.v1.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentService.Data;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using AppointmentService.Contracts.v1.Requests.Filter;
using AppointmentService.Contracts.v1.Responses;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AppointmentService.Options;
using AppointmentService.Domain.v1.UserDefenition;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Select;

namespace AppointmentService.Services.v1.Implementation
{
    public class AuthenticationManagerService : IAuthenticationManagerService
    {
        private readonly DBAppointmentContext _dataContext;
        private readonly string key;
        private Domain.v1.UserDefenition.User user = null;

        public AuthenticationManagerService(DBAppointmentContext dataContext, string key)
        {
            this.key = key;
            _dataContext = dataContext;
        }

        public Login Authenticate(LoginRequest loginRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                User result=null;
                try
                {
                    result = connection.QuerySingle<User>("sp_Authenticate", commandType: System.Data.CommandType.StoredProcedure, param: loginRequest);
                } catch (Exception ex) {
                    //Console.WriteLine(ex);
                    throw(ex);
                    
                };


                user = result;
                if (user is null)
                {
                    return null;
                }
                else
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(key);

                    var claims = new ClaimsIdentity();
                    foreach (var permission in user.Permissions.Split(','))
                    {
                        claims.AddClaims(new[]
                        {
                    new Claim(Permissions.Permission,permission)
                });
                    }

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return new Login
                    {
                        token = tokenHandler.WriteToken(token),
                        user = user,
                        expire = tokenDescriptor.Expires.Value
                    };
                }

            }
        }

        public Domain.v1.UserDefenition.User GetCurrentUser()
        {
            return user;
        }

        public async Task<OTPSResponse> GetOTP(GetOTPRequest getOTPRequest)
        {
            Random random = new Random();

            CreateOTPRequest createOTPRequest = new CreateOTPRequest
            {
                Mobile = getOTPRequest.Mobile,
                OTP = random.Next(10000, 99999),
                Type = getOTPRequest.Type
            };

            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QuerySingleAsync<OTPSResponse>("Sp_RegisterOTP", commandType: System.Data.CommandType.StoredProcedure,param: createOTPRequest);
                
                return result;
            }
        }

        //public bool HasActiveOTP(SelectOTPRequest selectOTPRequest)
        //{
        //    using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        //    {
        //        connection.Open();
        //        var result = connection.QuerySingle<bool>("Sp_HasActiveOTP", commandType: System.Data.CommandType.StoredProcedure, param: selectOTPRequest);
        //        return result;
        //    }
            
        //}

        public bool isRegistered(string mobile)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = connection.QuerySingle<bool>("Sp_isMobileRegistered", commandType: System.Data.CommandType.StoredProcedure, param: new { Mobile=mobile});
                return result;
            }
        }

        public Login Register(CreateRegisterRequest createRegisterRequest)
        {
            Login login = null;

            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                
                var created = connection.ExecuteScalar<bool>("Sp_RegisterUser", param: createRegisterRequest, commandType: System.Data.CommandType.StoredProcedure);
                if (created)
                {
                    LoginRequest loginRequest = new LoginRequest
                    {
                        Mobile = createRegisterRequest.Mobile,
                        Password= createRegisterRequest.Password
                    };


                    login = Authenticate(loginRequest);
                }
                return login;
            }
        }

        public async Task<bool> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();

                var created = await connection.ExecuteScalarAsync<bool>("Sp_UpdatePassword", param: updatePasswordRequest, commandType: System.Data.CommandType.StoredProcedure);

                return created;
            }
        }
    }
}
