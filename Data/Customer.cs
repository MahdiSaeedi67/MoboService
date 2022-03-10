using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public int UserId { get; set; }

    }
}
