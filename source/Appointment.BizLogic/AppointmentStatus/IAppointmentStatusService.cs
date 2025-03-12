using Appointment.Models.Domain;
//using Appointment.Models.DTOs;
using Appointment.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.BizLogic.Appointment
{
    public interface IAppointmentStatusService
    {
        Task<AppointmentStatusDTO> GetAppointmentStatusAsync(int appointmentStatusId);
        Task<List<AppointmentStatusDTO>> GetAllAppointmentStatusesAsync();
      
    }
}
