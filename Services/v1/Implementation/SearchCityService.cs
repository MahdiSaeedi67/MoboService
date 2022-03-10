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
using AppointmentService.Contracts.v1.Requests.Filter;

namespace AppointmentService.Services.v1.Implementation
{
    public class SearchCityService : ISearchCityService
    {
        private readonly DBAppointmentContext _dataContext;
        public SearchCityService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<SearchCityResponse>> Search(FilterSearchCityRequest filterSearchCityRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<SearchCityResponse>("SP_SearchCity", param: filterSearchCityRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
          
        }


    }
}
