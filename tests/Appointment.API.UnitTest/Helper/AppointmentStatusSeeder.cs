using Appointment.DAC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.API.UnitTest.Helper
{
    public class AppointmentStatusSeeder
    {
        public void Seed(SqlDbContext sqlDbContext)
        {
            sqlDbContext.AppointmentStatuses.Add(new Models.Domain.AppointmentStatus
            {
                AppointmentStatusId = 1,
                AppointmentStatusName="New",
            });
        }
    }
}
