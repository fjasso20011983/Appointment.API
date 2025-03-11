using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Domain
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        // Relaciones
        public ICollection<User> Users { get; set; }
    }
}
