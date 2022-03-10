using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Contracts.v1.Requests.Filter
{
    public class FilterBankAgreementRequest
    {
        public int? Codsh { get; set; }
        public int? BeginDate { get; set; }
        public int? EndDate { get; set; }

    }
}
