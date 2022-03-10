using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class OTPSResponse
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public int OTP { get; set; }
        public bool State { get; set; }
        public int Type { get; set; }
        public DateTime Time { get; set; }
    }
}
