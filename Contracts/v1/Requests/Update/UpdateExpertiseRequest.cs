using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Update
{
    public class UpdateExpertiseRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int ParentId { get; set; }

    }
}
