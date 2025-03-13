using Appointment.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Models.Request
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentStatusId { get; set; } 
        public string AppointmentStatusName { get; set; }
    }

}
