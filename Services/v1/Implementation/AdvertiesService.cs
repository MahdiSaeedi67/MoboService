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
using AppointmentService.Contracts.v1.Requests.Select;

namespace AppointmentService.Services.v1.Implementation
{
    public class AdvertiesService : IAdvertiesService
    {
        private readonly DBAppointmentContext _dataContext;
        public AdvertiesService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Adverties> GetById(int Id)
        {
            return await _dataContext.Adverties.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<AdvertiesResponse>> GetAll(SelectActiveAdvertiesRequest selectActiveAdvetiesRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<AdvertiesResponse>("SP_SelActiveAdverties", param: selectActiveAdvetiesRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }

        }

        public async Task<bool> Create(Adverties adverties)
        {
            //using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            //{
            //    await connection.OpenAsync();
            //    var parameters = new { Date = meeting.Date,Title=meeting.Title,Branch=meeting.Branch,Reagent=meeting.Reagent,UserId=1693,Type=meeting.Type };
            //    var result = await connection.ExecuteScalarAsync<int>("sp_InsertMeeting", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

            //    return result ;
            //}

            await _dataContext.Adverties.AddAsync(adverties);
            var created = await _dataContext.SaveChangesAsync();
                
            return created > 0;
        }
        public async Task<bool> Update(Adverties adverties)
        {

            _dataContext.Adverties.Update(adverties);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> Delete(int Id)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();
                var parameters = new { ExpertiseId = Id };
                var result = await connection.ExecuteAsync("sp_DeleteAdverties", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            }

        }

        


    }
}
