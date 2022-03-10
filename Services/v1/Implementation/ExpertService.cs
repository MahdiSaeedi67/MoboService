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
    public class ExpertService : IExpertService
    {
        private readonly DBAppointmentContext _dataContext;
        public ExpertService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ExpertResponse> GetById(int Id)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var parameters = new { ExpertID = Id };
                var result = await connection.QuerySingleAsync<ExpertResponse>("SP_SelExpertByExpertID", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            
        }

        public async Task<List<ExpertResponse>> GetAll()
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<ExpertResponse>("sp_GetAllExpert", commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }

            //return await _dataContext.Meeting.AsNoTracking().Select(q => new MeetingResponse
            //{
            //    Id = q.Id,
            //    Serial = q.Serial,
            //    Date = q.Date,
            //    Title = q.Title,
            //    Branch = q.Branch,
            //    BranchTitle = null,
            //    Reagent = q.Reagent,
            //    ReagentTitle = null,
            //    UserId = q.UserId,
            //    UserName = null,
            //    RegisterDate = q.RegisterDate,
            //    Type = q.Type,
            //    TypeTitle = null
            //}).ToListAsync();
            //return await _dataContext.Meeting.ToListAsync();
        }

        public async Task<bool> Create(Expert expert)
        {
            //using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            //{
            //    await connection.OpenAsync();
            //    var parameters = new { Date = meeting.Date,Title=meeting.Title,Branch=meeting.Branch,Reagent=meeting.Reagent,UserId=1693,Type=meeting.Type };
            //    var result = await connection.ExecuteScalarAsync<int>("sp_InsertMeeting", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            //    return result ;
            //}

            await _dataContext.Expert.AddAsync(expert);
            var created = await _dataContext.SaveChangesAsync();
                
            return created > 0;
        }
        public async Task<bool> Update(Expert expert)
        {

            _dataContext.Expert.Update(expert);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> Delete(int Id)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();
                var parameters = new { ExpertId = Id };
                var result = await connection.ExecuteAsync("sp_DeleteExpert", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            }


            //var meeting = await GetById(Id);

            //if (meeting == null)
            //    return false;
            //_dataContext.Meeting.Remove(meeting);
            //var deleted = await _dataContext.SaveChangesAsync();

            //return deleted > 0;
        }

        public async Task<List<ExpertResponse>> GetAllBetterExpertise(CreateBetterExpertRequest createBetterExpertRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                //var parameters = new { PageIndex = createBetterExpertRequest.PageId, PageSize = createBetterExpertRequest.PageSize };
                var result = await connection.QueryAsync<ExpertResponse>("SP_SelBetterExpertise", param: createBetterExpertRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
          
        }

        public async Task<List<ExpertResponse>> GetExpertsByExpertiseId(SelectExpertByExpertiseIdRequest selectExpertByExpertiseIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<ExpertResponse>("SP_SelExpertByExpertiseID", param: selectExpertByExpertiseIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
