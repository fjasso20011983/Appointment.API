using Appointment.DAC.Repositories;
using Appointment.Models.Request;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Appointment.BizLogic.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(Guid userGuid)
        {
            var user = await _userRepository.GetUserAsync(userGuid);
            //con mapper
            //UserDto userDto = new UserDto { UserId = user.UserId };
            UserDto userDto = _mapper.Map<Models.Domain.User, UserDto>(user);
            return userDto;
        }
    }
}
