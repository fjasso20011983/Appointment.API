using System;
using System.Collections.Generic;
using System.Text;
using Appointment.Models.Request;
using AutoMapper;
using Appointment.Models.Domain;

namespace Appointment.BizLogic.utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Models.Domain.User, UserDto>();
            CreateMap<Models.Domain.Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Models.Domain.Appointment>();
        }
    }
}
