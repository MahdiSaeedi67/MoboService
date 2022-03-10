using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Select
{
    public class SelectFreeAppointmentDateByExpertIdRequest
    {
        [Required]
        public int ExpertId { get; set; }
       

    }
}
