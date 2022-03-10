using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class AdvertiesResponse
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string Reference { get; set; }
        public bool Status { get; set; }
    }
}
