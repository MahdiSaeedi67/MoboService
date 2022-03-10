using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class Appointment
    {
        public Appointment()
        {

        }

        public long Id { get; set; }
        public int ExpertId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime MiladiDate { get; set; }
        public int ShamsiDate { get; set; }
        public int Time { get; set; }
        public byte State { get; set; }
        public long? AppointmentTypeId { get; set; }
        public string OpinionText { get; set; }
        public byte? OpinionScore { get; set; }
        public byte? OpinionState { get; set; }
    }
}
