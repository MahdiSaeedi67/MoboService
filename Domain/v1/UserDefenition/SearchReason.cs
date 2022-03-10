using System;
using System.Collections.Generic;

namespace AppointmentService.Domain.v1
{
    public partial class SearchReason
    {
        public SearchReason()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int ReasonType { get; set; }
    }
}
