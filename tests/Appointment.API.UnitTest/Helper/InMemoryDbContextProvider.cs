using Appointment.DAC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.API.UnitTest.Helper
{
    public class InMemoryDbContextProvider
    {
        private readonly DbContextOptions<SqlDbContext> options;

        public InMemoryDbContextProvider()
        {
            options = new DbContextOptionsBuilder<SqlDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

        public SqlDbContext CreateContext()
        {
            var context = new SqlDbContext(options);

            SeedUser(context);
            SeedAppointmentStatus(context);
            SeedAppointment(context);

            context.SaveChanges();
            return context;
        }

        public void SeedUser(SqlDbContext context)
        {
            UserSeeder userSeeder = new UserSeeder();
            userSeeder.Seed(context);
        }
        public void SeedAppointment(SqlDbContext context)
        {
            AppointmentSeeder appointmentSeeder = new AppointmentSeeder();
            appointmentSeeder.Seed(context);
        }

        public void SeedAppointmentStatus(SqlDbContext context)
        {
            AppointmentStatusSeeder appointmentStatusSeeder = new AppointmentStatusSeeder();
            appointmentStatusSeeder.Seed(context);
        }

    }
}
