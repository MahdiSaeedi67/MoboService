using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class Users
    {
        public Users()
        {

        }
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }


    }
}
