using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Update
{
    public class UpdateSetAppointmentRequest
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }


    }
}
