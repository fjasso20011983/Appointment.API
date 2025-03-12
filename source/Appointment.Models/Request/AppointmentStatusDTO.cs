using Appointment.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Request
{
    public class AppointmentStatusDTO
    {
        public int AppointmentStatusId { get; set; }
        public string AppointmentStatusName { get; set; }
    }

}
