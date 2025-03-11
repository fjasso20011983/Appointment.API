using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appointment.BizLogic.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Appointment.API.Controllers
{
    [Route("[controller]")]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [Route("{userGuid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid userGuid)
        {
            var user = await _userService.GetUserAsync(userGuid);
            return Ok(user);
        }
    }
}
