using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class Report
    {
        public long Id { get; set; }
        public int? ReportType { get; set; }
        public int? State { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int? ShamsiRegisterDate { get; set; }
    }
}
