using Appointment.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.DAC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbContext _context;

        public UserRepository(SqlDbContext context)
        {
            this._context = context;
        }

        public async Task<User> GetUserAsync(Guid userGuid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserGuid.Equals(userGuid));
            return user;
        }
    }
}
