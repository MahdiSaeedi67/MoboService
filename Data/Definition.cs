using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class Definition
    {
        public int Id { get; set; }
        public int DefinitionTypeId { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }
    }
}
