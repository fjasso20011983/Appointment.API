using Appointment.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.DAC.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly SqlDbContext _context;

        public AppointmentRepository(SqlDbContext context)
        {
            this._context = context;
        }

        public async Task<Models.Domain.Appointment> GetAppointmentAsync(int appointmentId)
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.AppointmentStatus)
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
        }

        public async Task<List<Models.Domain.Appointment>> GetAppointmentsAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.AppointmentStatus)
                .ToListAsync();
        }

        public async Task<List<Models.Domain.Appointment>> GetAppointmentsByUserAsync(int userId)
        {
            return await _context.Appointments
                .Where(a => a.UserId == userId)
                .Include(a => a.AppointmentStatus)
                .ToListAsync();
        }

        public async Task AddAppointmentAsync(Models.Domain.Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(Models.Domain.Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
