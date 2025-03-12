using Appointment.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.DAC.Repositories
{   
    public interface IAppointmentStatusRepository
    {
        Task<Models.Domain.AppointmentStatus> GetAppointmentStatusAsync(int appointmentStatusId);
        Task<List<Models.Domain.AppointmentStatus>> GetAppointmentsStatusesAsync();
   
    }
}
