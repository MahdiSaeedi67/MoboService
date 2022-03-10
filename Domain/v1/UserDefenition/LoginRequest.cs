using System;
using System.Collections.Generic;

namespace AppointmentService.Domain
{
    public partial class LoginRequest
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}
