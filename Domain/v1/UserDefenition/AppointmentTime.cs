using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class AppointmentTime
    {
        public AppointmentTime()
        {

        }

        public int Id { get; set; }
        public string Time { get; set; }
        public Byte State { get; set; }
    }
}
