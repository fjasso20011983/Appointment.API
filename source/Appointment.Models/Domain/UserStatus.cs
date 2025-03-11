using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Domain
{
    public class UserStatus
    {
        public int UserStatusId { get; set; }
        public string UserStatusName { get; set; }

        // Relaciones
        public ICollection<User> Users { get; set; }
    }
}
