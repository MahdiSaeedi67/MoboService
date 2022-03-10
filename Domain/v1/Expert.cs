using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class Expert
    {
        public Expert()
        {

        }

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
        public string Address { get; set; }
        public int? ExpertiseId { get; set; }
        public string Sheba { get; set; }
        public string Keyword { get; set; }
        public int UserId { get; set; }
    }
}
