using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class Transaction
    {
        public long Id { get; set; }
        public long? AuthorityId { get; set; }
        public long? RefId { get; set; }
        public long Amount { get; set; }
        public DateTime MiladiDate { get; set; }
        public int ShamsiDate { get; set; }
        public byte State { get; set; }
        public int PayType { get; set; }
        public long OrderId { get; set; }
    }
}
