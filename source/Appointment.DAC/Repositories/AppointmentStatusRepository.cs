using Appointment.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.DAC.Repositories
{
    public class AppointmentStatusRepository : IAppointmentStatusRepository
    {
        private readonly SqlDbContext _context;

        public AppointmentStatusRepository(SqlDbContext context)
        {
            this._context = context;
        }

        public async Task<Models.Domain.AppointmentStatus> GetAppointmentStatusAsync(int appointmentStatusId)
        {
            return await _context.AppointmentStatuses
               .FirstOrDefaultAsync(a => a.AppointmentStatusId == appointmentStatusId);
        }

        public async Task<List<Models.Domain.AppointmentStatus>> GetAppointmentsStatusesAsync()
        {
            return await _context.AppointmentStatuses
                .ToListAsync();
        }

    }
}
