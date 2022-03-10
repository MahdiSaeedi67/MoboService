using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Update
{
    public class UpdateAppointmentRequest
    {
        public byte State { get; set; }
        public string OpinionText { get; set; }
        public byte? OpinionScore { get; set; }
        public byte? OpinionState { get; set; }


    }
}
