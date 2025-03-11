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

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this._appointmentRepository = appointmentRepository;
            this._mapper = mapper;
        }

        public async Task<AppointmentDTO> GetAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(appointmentId);
            var appointmentDto = _mapper.Map<Models.Domain.Appointment, AppointmentDTO>(appointment);
            return appointmentDto;
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

        public async Task UpdateAppointmentAsync(int appointmentId, AppointmentDTO appointmentDto)
        {
            var oldAppointment = await _appointmentRepository.GetAppointmentAsync(appointmentId); 
            _mapper.Map<AppointmentDTO, Models.Domain.Appointment>(appointmentDto, oldAppointment);
            await _appointmentRepository.UpdateAppointmentAsync(oldAppointment);
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
        }
    }
}
