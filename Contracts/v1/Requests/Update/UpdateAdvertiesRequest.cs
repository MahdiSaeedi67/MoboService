using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Update
{
    public class UpdateAdvertiesRequest
    {
        [Required]
        public int Type { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desciption { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}
