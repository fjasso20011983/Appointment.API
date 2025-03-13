using Appointment.DAC.Repositories;
using Appointment.Models.Domain;
//using Appointment.Models.DTOs;
using Appointment.Models.Request;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.BizLogic.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private List<string> _invalidUpdateDeleteStatus; 

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this._appointmentRepository = appointmentRepository;
            this._mapper = mapper;
            _invalidUpdateDeleteStatus = new List<string> { "Approved", "Cancelled" };
        }

        public async Task<AppointmentDTO> GetAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(appointmentId);
            var appointmentDto = _mapper.Map<Models.Domain.Appointment, AppointmentDTO>(appointment);
            return appointmentDto;
        }

        public async Task<List<AppointmentDTO>> GetAppointmentsAllAsync()
        {
            var appointments = await _appointmentRepository.GetAppointmentsAllAsync();
            var appointmentDtos = _mapper.Map<List<Models.Domain.Appointment>, List<AppointmentDTO>>(appointments);
            return appointmentDtos;
        }

        public async Task<List<AppointmentDTO>> GetAppointmentsByUserAsync(int userId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByUserAsync(userId);
            var appointmentDtos = _mapper.Map<List<Models.Domain.Appointment>, List<AppointmentDTO>>(appointments);
            return appointmentDtos;
        }

        public async Task AddAppointmentAsync(AppointmentDTO appointmentDto)
        {
            var appointment = _mapper.Map<AppointmentDTO, Models.Domain.Appointment>(appointmentDto);
            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task<(bool, string)> UpdateAppointmentAsync(int appointmentId, AppointmentDTO appointmentDto)
        {
            var oldAppointment = await _appointmentRepository.GetAppointmentAsync(appointmentId);
            
            if(oldAppointment == null)
            {
                return (false, "Invalid AppointmentId");
            }            

            _mapper.Map<AppointmentDTO, Models.Domain.Appointment>(appointmentDto, oldAppointment);
            await _appointmentRepository.UpdateAppointmentAsync(oldAppointment);
            
            return (true, "");
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
        }

        private (bool, string) ValidateUpdateDeleteStatus(string originalStatus, string newStatus)
        {
            if (_invalidUpdateDeleteStatus.Contains(originalStatus))
            {
                return (false, "Cannot update Appointment, please check the Appointment status");
            }

            if(newStatus.Equals("Deleted") && !originalStatus.Equals("Cancelled"))
            {
                return (false, "Cannot update Appointment, please check the Appointment status");
            }

            return (true, "");
        }
    }
}
