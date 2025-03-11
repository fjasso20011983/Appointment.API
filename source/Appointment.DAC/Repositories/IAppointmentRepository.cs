using Appointment.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.DAC.Repositories
{   
    public interface IAppointmentRepository
    {
        Task<Models.Domain.Appointment> GetAppointmentAsync(int appointmentId);
        Task<List<Models.Domain.Appointment>> GetAppointmentsByUserAsync(int userId);
        Task AddAppointmentAsync(Models.Domain.Appointment appointment);
        Task UpdateAppointmentAsync(Models.Domain.Appointment appointment);
        Task DeleteAppointmentAsync(int appointmentId);
    }
}
