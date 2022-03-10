using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Update
{
    public class UpdateExpertRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string ExpertMobile { get; set; }
        public string SecretaryMobile { get; set; }
        public string VirtualMobile { get; set; }
        public string PictureAddress { get; set; }
        [Required]
        public string ExpertNo { get; set; }
        public string Comment { get; set; }
        [Required]
        public int? Province { get; set; }
        [Required]
        public int? County { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int? ExpertiseId { get; set; }
        public string Sheba { get; set; }
        public string Keyword { get; set; }

    }
}
