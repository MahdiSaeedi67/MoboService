using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Select
{
    public class SelectActiveAdvertiesRequest
    {
        [Required]
        public int PageIndex { get; set; }
        [Required] 
        public int PageSize { get; set; }
        
    }
}
