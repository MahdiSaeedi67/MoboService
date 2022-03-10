using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Create
{
    public class CreateRegisterRequest
    {
        [Required]
        public string Mobile { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public int OTP { get; set; }


    }
}
