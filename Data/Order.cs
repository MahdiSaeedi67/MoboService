using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class Order
    {
        public long Id { get; set; }
        public long AppointmentId { get; set; }
    }
}
