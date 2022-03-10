using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Filter
{
    public class FilterPersonRequest
    {
        public string? NationalCode { get; set; }
        public string? Name { get; set; }
        
        public string? Organization { get; set; }
        
        public string? Semat { get; set; }
        

    }
}
