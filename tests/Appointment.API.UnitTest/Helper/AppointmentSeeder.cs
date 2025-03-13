using Appointment.DAC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.API.UnitTest.Helper
{
    public class AppointmentSeeder
    {
        public void Seed(SqlDbContext sqlDbContext)
        {
            sqlDbContext.Appointments.Add(new Models.Domain.Appointment
            {
                AppointmentId = 1,
                AppointmentGuid = Guid.Parse("c34f5a8e-7c82-4e71-a1af-199d9e0c5919"),
                UserId = 1,
                Title = "Dentist Appointment Mock",
                Description= "Routine dental checkup.2",
                AppointmentDate= DateTime.Parse("2025-03-11 16:30:00.0000000"),
                AppointmentStatusId=1
            });
        }
    }
}
