using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class ExpertiseResponse
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public int SubCategoryCount { get; set; }
        public int SubItemsCount { get; set; }
        public int ReasonType { get; set; }
        


    }
}
