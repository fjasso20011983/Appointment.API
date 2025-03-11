using Appointment.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.DAC.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid userGuid);
    }
}
