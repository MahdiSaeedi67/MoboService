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
    public class SearchService : ISearchService
    {
        private readonly DBAppointmentContext _dataContext;
        public SearchService(DBAppointmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<SearchResponse>> Search(FilterSearchRequest filterSearchRequest)
        {
            using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<SearchResponse>("SP_Search", param: filterSearchRequest, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
          
        }


    }
}
