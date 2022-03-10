using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class Adverties
    {
        public Adverties()
        {

        }
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string Reference { get; set; }
        public bool Status { get; set; }
    }
}
