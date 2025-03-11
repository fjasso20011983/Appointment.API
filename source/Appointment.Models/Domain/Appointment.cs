using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Domain
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public Guid AppointmentGuid { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentStatusId { get; set; }
        // Relaciones
        public User User { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public ICollection<AppointmentHistory> AppointmentHistories { get; set; }
    }
}
