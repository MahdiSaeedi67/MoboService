using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class SearchCityResponse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int ReasonType { get; set; }
        public int SubItemsCount { get; set; }

    }
}
