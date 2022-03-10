using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class Wallet
    {
        public long Id { get; set; }
        public int? OwnerId { get; set; }
        public byte? WalletType { get; set; }
        public long? Amount { get; set; }
        public int? TransactionType { get; set; }
        public int? TransactionDescription { get; set; }
        public DateTime? Transactiondate { get; set; }
        public int? ShamsiTransactionDate { get; set; }
    }
}
