using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Create
{
    public class CreateAppointmentRequest
    {
        [Required]
        public int ExpertId { get; set; }
        [Required]
        public string FromDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public int FromTime { get; set; }
        [Required]
        public int EndTime { get; set; }
        [Required]
        public Int64 VisitTime { get; set; }
        [Required]
        public int AppointmentTypeID { get; set; }
        

    }
}
