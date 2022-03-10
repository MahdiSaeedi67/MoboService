using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1

{
    public partial class AppointmentType
    {
        public AppointmentType()
        {

        }

        public long Id { get; set; }
        public string Title { get; set; }
        public int ExpertId { get; set; }
        public long Price { get; set; }
        public string Comment { get; set; }
    }
}
