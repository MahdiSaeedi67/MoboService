using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1

{
    public partial class OTPS
    {
        public OTPS()
        {

        }

        public int Id { get; set; }
        public string Mobile { get; set; }
        public int OTP { get; set; }
        public bool State { get; set; }
        public int Type { get; set; }
        public DateTime Time { get; set; }
    }
}
