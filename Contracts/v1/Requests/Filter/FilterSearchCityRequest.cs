using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Filter
{
    public class FilterSearchCityRequest
    {
        public string City { get; set; }
        
    }
}
