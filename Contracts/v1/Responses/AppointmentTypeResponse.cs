using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class AppointmentTypeResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int ExpertId { get; set; }
        public long Price { get; set; }
        public string Comment { get; set; }

    }
}
