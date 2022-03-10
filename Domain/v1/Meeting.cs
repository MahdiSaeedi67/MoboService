using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class Meeting
    {
        public Meeting()
        {

        }

        public int Id { get; set; }
        public long? Serial { get; set; }
        public int Date { get; set; }
        public string Title { get; set; }
        public int Branch { get; set; }
        public int Reagent { get; set; }
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public short Type { get; set; }


    }
}
