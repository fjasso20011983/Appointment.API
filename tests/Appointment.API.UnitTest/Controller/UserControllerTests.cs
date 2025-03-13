using System;
using System.Collections.Generic;
using System.Text;
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

namespace Appointment.API.UnitTest.Controller
{
    public class UserControllerTests
    {
        private readonly SqlDbContext sqlDbContext;
        private readonly IMapper mapper;

        public UserControllerTests()
        {
            var provider = new InMemoryDbContextProvider();
            sqlDbContext = provider.CreateContext();

            var conf = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            this.mapper = conf.CreateMapper();
        }

        [Fact]
        public async Task UserController_ShouldGetUser()
        {
            //Arrange
            UserRepository userRepository = new UserRepository(sqlDbContext);
            UserService userService = new UserService(userRepository, mapper);
            UserController userController = new UserController(userService);

            //Act
            var actionResutl = await userController.GetUser(Guid.Parse("68874d37-304b-4d49-bc18-f7c59a2fd718"));
            var objectResult = (ObjectResult)actionResutl;
            var result = objectResult.Value;

            //Assert
            Assert.Equal(200, objectResult.StatusCode);
            Assert.Equal("Fabiola", ((UserDto)result).FirstName);
        }

        [Fact]
        public async Task UserController_ShouldFailIfUserNotFound()
        {
            //Arrange
            UserRepository userRepository = new UserRepository(sqlDbContext);
            UserService userService = new UserService(userRepository, mapper);
            UserController userController = new UserController(userService);

            //Act
            var actionResutl = await userController.GetUser(Guid.Parse("68874d37-304b-4d49-bc18-f7c59a2fd717"));
            var objectResult = (ObjectResult)actionResutl;
            var result = GetDynamicObject(objectResult.Value);

            //Assert
            Assert.Equal(400, objectResult.StatusCode);
            Assert.Equal("Invalid userGuid", Convert.ToString(result.Error));
        }

        private dynamic GetDynamicObject(object value)
        {
            var jsonObject = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<dynamic>(jsonObject);
        }
    }
}
