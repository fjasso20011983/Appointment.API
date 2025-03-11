using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Domain
{
    public class AppointmentStatus
    {
        public int AppointmentStatusId { get; set; }
        public string AppointmentStatusName { get; set; }

        // Relaciones
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<AppointmentHistory> AppointmentHistories { get; set; }

    }
}
