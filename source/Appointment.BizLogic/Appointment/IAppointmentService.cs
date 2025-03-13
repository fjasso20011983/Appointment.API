using Appointment.Models.Domain;
//using Appointment.Models.DTOs;
using Appointment.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.BizLogic.Appointment
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> GetAppointmentAsync(int appointmentId);
        Task<List<AppointmentDTO>> GetAppointmentsAllAsync();
        Task<List<AppointmentDTO>> GetAppointmentsByUserAsync(int userId);
        Task AddAppointmentAsync(AppointmentDTO appointmentDto);
        Task<(bool, string)> UpdateAppointmentAsync(int appointmentId, AppointmentDTO appointmentDto);
        Task DeleteAppointmentAsync(int appointmentId);
    }
}
