using System;
using System.Threading.Tasks;
using Xunit;
using Appointment.API.Controllers;
using Moq;
using Appointment.BizLogic.User;
using Appointment.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Appointment.DAC;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Appointment.API.UnitTest.Helper;
using Appointment.DAC.Repositories;
using AutoMapper;
using Appointment.BizLogic.utils;
using Appointment.BizLogic.Appointment;
using Appointment.BizLogic.AppointmentStatus;

namespace Appointment.API.UnitTest.Controller
{
    public class AppointmentControllerTests
    {
        private readonly SqlDbContext sqlDbContext;
        private readonly IMapper mapper;

        public AppointmentControllerTests()
        {
            var provider = new InMemoryDbContextProvider();
            sqlDbContext = provider.CreateContext();

            var conf = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            this.mapper = conf.CreateMapper();
        }

        [Fact]
        public async Task AppointmentController_ShouldGetAppointment()
        {
            //Arrange
            AppointmentRepository appointmentRepository = new AppointmentRepository(sqlDbContext);
            AppointmentStatusRepository appointmentStatusRepository = new AppointmentStatusRepository(sqlDbContext);
            AppointmentService appointmentService = new AppointmentService(appointmentRepository, mapper);
            AppointmentStatusService appointmentStatusService = new AppointmentStatusService(appointmentStatusRepository, mapper);
            AppointmentController appointmentController = new AppointmentController(appointmentService,appointmentStatusService);

            //Act
            var actionResutl = await appointmentController.GetAppointment(1);
            var objectResult = (ObjectResult)actionResutl;
            var result = objectResult.Value;

            //Assert
            Assert.Equal(200, objectResult.StatusCode);
            Assert.Equal(1, ((AppointmentDTO)result).AppointmentId);
        }

        [Fact]
        public async Task AppointmentController_ShouldFailIfAppointmentNotFound()
        {
            //Arrange
            AppointmentRepository appointmentRepository = new AppointmentRepository(sqlDbContext);
            AppointmentStatusRepository appointmentStatusRepository = new AppointmentStatusRepository(sqlDbContext);
            AppointmentService appointmentService = new AppointmentService(appointmentRepository, mapper);
            AppointmentStatusService appointmentStatusService = new AppointmentStatusService(appointmentStatusRepository, mapper);
            AppointmentController appointmentController = new AppointmentController(appointmentService, appointmentStatusService);

            //Act
            var actionResutl = await appointmentController.GetAppointment(1111);
            var objectResult = (ObjectResult)actionResutl;
            var result = GetDynamicObject(objectResult.Value);

            //Assert
            Assert.Equal(400, objectResult.StatusCode);
            Assert.Equal("Invalid AppointmentId", Convert.ToString(result.Error));
        }

        private dynamic GetDynamicObject(object value)
        {
            var jsonObject = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<dynamic>(jsonObject);
        }
    }
}
