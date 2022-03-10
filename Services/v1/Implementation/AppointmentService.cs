using System;
using System.Collections.Generic;

using AppointmentService.Services.v1.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentService.Domain;
using AppointmentService.Domain.v1;
using AppointmentService.Data;
using System.Linq;
using AppointmentService.Contracts.v1.Responses;
using System.Data.SqlClient;
using Dapper;
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Update;

namespace AppointmentService.Services.v1.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DBAppointmentContext _dataContext;
        public AppointmentService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Appointment> GetById(int Id)
        {
            return await _dataContext.Appointment.SingleOrDefaultAsync(x => x.Id == Id);
            //using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            //{
            //    connection.Open();
            //    var parameters = new { ExpertID = Id };
            //    var result = await connection.QuerySingleAsync<AppointmentResponse>("SP_SelExpertByExpertID", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            //    return result;
            //}

        }

        //public async Task<List<AppointmentResponse>> GetAll()
        //{
        //    using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<AppointmentResponse>("sp_GetAllAppointment", commandType: System.Data.CommandType.StoredProcedure);
        //        return result.ToList();
        //    }

        //}

        public async Task<bool> Create(CreateAppointmentRequest createAppointmentRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();
                //var parameters = new { Date = meeting.Date, Title = meeting.Title, Branch = meeting.Branch, Reagent = meeting.Reagent, UserId = 1693, Type = meeting.Type };
                var result = await connection.ExecuteScalarAsync<int>("SP_InsAppointment", param: createAppointmentRequest, commandType: System.Data.CommandType.StoredProcedure);

                return result>0;
            }

            //await _dataContext.Appointment.AddAsync(appointment);
            //var created = await _dataContext.SaveChangesAsync();
                
            //return created > 0;
        }
        public async Task<bool> Update(Appointment appointment)
        {

            _dataContext.Appointment.Update(appointment);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> Delete(int Id)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();
                var parameters = new { ExpertId = Id };
                var result = await connection.ExecuteAsync("sp_DeleteAppointment", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            }

         
        }

        public async Task<List<AppointmentDateResponse>> GetFreeAppointmentDateByExpertID(SelectFreeAppointmentDateByExpertIdRequest selectFreeAppointmentDateByExpertIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                //var parameters = new { PageIndex = createBetterExpertRequest.PageId, PageSize = createBetterExpertRequest.PageSize };
                var result = await connection.QueryAsync<AppointmentDateResponse>("SP_SelActiveDateByExpertID", param: selectFreeAppointmentDateByExpertIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
          
        }
        public async Task<List<AppointmentTimeResponse>> GetAppointmentTimesByExpertID(SelectAppointmentTimeByExpertIdRequest selectAppointmentTimeByExpertIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<AppointmentTimeResponse>("SP_SelTimeByExpertID", param: selectAppointmentTimeByExpertIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }

        }

        public async Task<List<AppointmentTypeResponse>> GetAppointmentTypeByExpertID(SelectAppointmentTypeByExpertIdRequest selectAppointmentTypeByExpertIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<AppointmentTypeResponse>("SP_SelAppointmentTypeByExpertID", param: selectAppointmentTypeByExpertIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }

        }
        public async Task<List<AppointmentResponse>> GetAppointmentByCustomerID(SelectAppointmentByCustomerIdRequest selectAppointmentByCustomerIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<AppointmentResponse>("SP_SelAppointmentByCustomerID", param: selectAppointmentByCustomerIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }

        }

        public async Task<bool> SetAppointment(UpdateSetAppointmentRequest updateSetAppointmentRequest)
        {
            var result = false;
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var i=await connection.ExecuteAsync("Sp_SetAppointment", param: updateSetAppointmentRequest, commandType: System.Data.CommandType.StoredProcedure);
                result = i > 0;
            }
            return result;
                
        }

    }
}
