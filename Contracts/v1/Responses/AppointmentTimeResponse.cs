using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class AppointmentTimeResponse
    {
        public long AppointmentID { get; set; }
        public string Time { get; set; }
        public Byte state { get; set; }

    }
}
