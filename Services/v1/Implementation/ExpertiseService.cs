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
using AppointmentService.Contracts.v1.Requests.Create;

namespace AppointmentService.Services.v1.Implementation
{
    public class ExpertiseService : IExpertiseService
    {
        private readonly DBAppointmentContext _dataContext;
        public ExpertiseService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Expertise> GetById(int Id)
        {
            return await _dataContext.Expertise.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ExpertiseResponse>> GetAll()
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<ExpertiseResponse>("sp_GetAllExpertise", commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }

        }

        public async Task<bool> Create(Expertise expertise)
        {
            //using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            //{
            //    await connection.OpenAsync();
            //    var parameters = new { Date = meeting.Date,Title=meeting.Title,Branch=meeting.Branch,Reagent=meeting.Reagent,UserId=1693,Type=meeting.Type };
            //    var result = await connection.ExecuteScalarAsync<int>("sp_InsertMeeting", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            //    return result ;
            //}

            await _dataContext.Expertise.AddAsync(expertise);
            var created = await _dataContext.SaveChangesAsync();
                
            return created > 0;
        }
        public async Task<bool> Update(Expertise expertise)
        {

            _dataContext.Expertise.Update(expertise);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> Delete(int Id)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();
                var parameters = new { ExpertiseId = Id };
                var result = await connection.ExecuteAsync("sp_DeleteExpertise", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            }

        }

        public async Task<List<ExpertiseResponse>> GetAllExpertiseByCategoryId(CreateExpertiseByCategoryIdRequest createExpertiseByCategoryIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                //var parameters = new { PageIndex = createBetterExpertRequest.PageId, PageSize = createBetterExpertRequest.PageSize };
                var result = await connection.QueryAsync<ExpertiseResponse>("SP_SelExpertiseByParentID", param: createExpertiseByCategoryIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
          
        }


    }
}
