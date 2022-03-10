using System;
using System.Collections.Generic;

namespace AppointmentService.Data
{
    public partial class RolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

    }
}
