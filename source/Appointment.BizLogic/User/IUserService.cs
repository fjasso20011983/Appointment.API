using Appointment.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.BizLogic.User
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(Guid userGuid);
    }
}
