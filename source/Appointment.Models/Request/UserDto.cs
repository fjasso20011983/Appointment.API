using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Request
{
    public class UserDto
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public int UserStatusId { get; set; }
    }
}
