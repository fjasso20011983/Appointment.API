using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Domain
{
    public class AppointmentHistory
    {   public int AppointmentHistoryId { get; set; }
        public int AppointmentId { get; set; }
        public int AppointmentStatusId { get; set; }
        public DateTime ChangedOn { get; set; }
        public int ChangedBy { get; set; }
        // Relaciones
        public Appointment Appointment { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public User ChangedByUser { get; set; }
    }
}
