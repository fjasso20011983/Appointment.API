using System;
using System.Collections.Generic;

namespace Appointment.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public int UserStatusId { get; set; }

        // Relaciones
        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<AppointmentHistory> AppointmentHistories { get; set; }
    }
}
