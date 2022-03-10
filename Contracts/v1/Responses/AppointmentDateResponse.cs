using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class AppointmentDateResponse
    {
        public int ShamsiDate { get; set; }
        public int Num { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }

    }
}
