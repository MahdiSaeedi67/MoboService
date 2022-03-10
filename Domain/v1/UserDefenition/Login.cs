using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Domain.v1.UserDefenition
{
    public class Login
    {
        public string token { get; set; }
        public User user { get; set; }
        public DateTime expire { get; set; }
    }
}
