using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Create
{
    public class CreateExpertiseByCategoryIdRequest
    {
        [Required]
        public int ParentId { get; set; }
        [Required]
        public int PageIndex { get; set; }
        [Required] 
        public int PageSize { get; set; }
        
    }
}
