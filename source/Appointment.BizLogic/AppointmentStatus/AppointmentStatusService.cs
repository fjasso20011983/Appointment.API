using Appointment.BizLogic.Appointment;
using Appointment.DAC.Repositories;
using Appointment.Models.Domain;
using Appointment.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.BizLogic.AppointmentStatus
{
    public class AppointmentStatusService : IAppointmentStatusService
    {
        private readonly IAppointmentStatusRepository _appointmentStatusRepository;
        private readonly IMapper _mapper;

        public AppointmentStatusService(IAppointmentStatusRepository appointmentStatusRepository, IMapper mapper)
        {
            this._appointmentStatusRepository = appointmentStatusRepository;
            this._mapper = mapper;
        }

        public async Task<AppointmentStatusDTO> GetAppointmentStatusAsync(int appointmentStatusId)
        {
            var appointmentStatus = await _appointmentStatusRepository.GetAppointmentStatusAsync(appointmentStatusId);
            var appointmentStatusDto = _mapper.Map<Models.Domain.AppointmentStatus, AppointmentStatusDTO>(appointmentStatus);
            return appointmentStatusDto;
        }

        public async Task<List<AppointmentStatusDTO>> GetAllAppointmentStatusesAsync()
        {
            var appointmentStatuses = await _appointmentStatusRepository.GetAppointmentsStatusesAsync();
            var appointmentStatusDtos = _mapper.Map<List<Models.Domain.AppointmentStatus>, List<AppointmentStatusDTO>>(appointmentStatuses);
            return appointmentStatusDtos;
        }

     
    }
}