using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class Expertise
    {
        public Expertise()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
}
