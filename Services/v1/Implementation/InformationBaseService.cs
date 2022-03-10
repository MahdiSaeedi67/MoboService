using System;
using System.Collections.Generic;

using AppointmentService.Services.v1.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentService.Data;
using AppointmentService.Domain;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Contracts.v1.Requests.Select;

namespace AppointmentService.Services.v1.Implementation
{
    public class InformationBaseService : IInformationBaseService
    {
        private readonly DBAppointmentContext _dataContext;
        public InformationBaseService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<CountyResponse>> GetAllCountyByProvinceId(SelectCountyByProvinceIdRequest selectCountyByProvinceIdRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                    connection.Open();
                    var result = await connection.QueryAsync<CountyResponse>("SP_SelCountyByProvinceID", param: selectCountyByProvinceIdRequest, commandType: System.Data.CommandType.StoredProcedure);
                    return result.ToList();
                
            }
        }

        //public async Task<List<Branch>> BranchGetAll()
        //{
        //    using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<Branch>("sp_GetAllBranchs", commandType: System.Data.CommandType.StoredProcedure);
        //        return result.ToList();
        //    }
        //}

        //public async Task<List<Reagent>> ReagentGetAll(int branch)
        //{
        //    using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<Reagent>("sp_GetAllReagents", commandType: System.Data.CommandType.StoredProcedure, param: new { branch });
        //        return result.ToList();
        //    }
        //}
        //public async Task<List<MeetingType>> MeetingTypeGetAll()
        //{
        //    using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<MeetingType>("sp_GetAllMeetingType", commandType: System.Data.CommandType.StoredProcedure);
        //        return result.ToList();
        //    }
        //}

    }
}
