using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1.Responses
{
    public class SearchResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string ExpertiseTitle { get; set; }
        public string PictureAddress { get; set; }
        public int ReasonType { get; set; }
        public int SubCategoryCount { get; set; }
        public int SubItemsCount { get; set; }

    }
}
