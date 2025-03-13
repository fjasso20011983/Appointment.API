using Appointment.DAC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.API.UnitTest.Helper
{
    public class UserSeeder
    {
        public void Seed(SqlDbContext sqlDbContext)
        {
            sqlDbContext.Users.Add(new Models.Domain.User
            {
                UserId = 1,
                UserGuid = Guid.Parse("68874d37-304b-4d49-bc18-f7c59a2fd718"),
                FirstName = "Fabiola",
                LastName = "Jasso",
                UserStatusId = 2,
                UserTypeId = 2
            });
        }
    }
}
