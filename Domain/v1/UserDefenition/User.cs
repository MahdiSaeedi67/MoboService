using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Domain.v1.UserDefenition
{
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Permissions { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
