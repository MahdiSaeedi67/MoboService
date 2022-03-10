using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Create
{
    public class UpdateUserInformationRequest
    {
        [Required]
        public int UserId { get; set; }
        
        public string Name { get; set; }
        
        public string Family { get; set; }


    }
}
