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
    public class UserManagmentService : IUserManagmentService
    {
        private readonly DBAppointmentContext _dataContext;

        public UserManagmentService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> UpdateUserInformation(UpdateUserInformationRequest updateUserInformationRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();

                var created = await connection.ExecuteScalarAsync<bool>("Sp_UpdateUserInformation", param: updateUserInformationRequest, commandType: System.Data.CommandType.StoredProcedure);

                return created;
            }
        }
    }
}
