using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class AppointmentResponse
    {
        public long Id { get; set; }
        public int ExpertId { get; set; }
        public string ExpertName { get; set; }
        public string ExpertiseTitle { get; set; }
        public int? CustomerId { get; set; }
        public DateTime MiladiDate { get; set; }
        public int ShamsiDate { get; set; }
        public int Time { get; set; }
        public  string FormatedTime { get; set; }
        public byte State { get; set; }
        public long? AppointmentTypeId { get; set; }
        public string AppointmentTypeTitle { get; set; }
        public string OpinionText { get; set; }
        public byte? OpinionScore { get; set; }
        public byte? OpinionState { get; set; }



    }
}
