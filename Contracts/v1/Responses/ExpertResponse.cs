using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class ExpertResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Tel { get; set; }
        public string ExpertMobile { get; set; }
        public string SecretaryMobile { get; set; }
        public string VirtualMobile { get; set; }
        public string PictureAddress { get; set; }
        public string ExpertNo { get; set; }
        public string Comment { get; set; }
        public int? Province { get; set; }
        public int? County { get; set; }
        public string CountyTitle { get; set; }
        public string Address { get; set; }
        public int? ExpertiseId { get; set; }
        public string ExpertiseTitle { get; set; }
        public string Sheba { get; set; }
        public string Keyword { get; set; }
        public int VoteCount { get; set; }
        public int ReasonType { get; set; }
    }
}
