using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appointment.BizLogic.Appointment;
using Appointment.Models.Domain;
using Appointment.Models.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers
{
    [Route("[controller]")]
    public class AppointmentController : ApiBaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentStatusService _appointmentStatusService;

        public AppointmentController(IAppointmentService appointmentService, IAppointmentStatusService appointmentStatusService)
        {
            this._appointmentService = appointmentService;
            this._appointmentStatusService = appointmentStatusService;
        }

        [HttpGet]
        [Route("{appointmentId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetAppointment([FromRoute] int appointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(appointmentId);
            if (appointment == null)
            {
                return BadRequest(new { Error = "Invalid AppointmentId" });
            }
            return Ok(appointment);
        }

        [HttpGet]
        [Route("")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetAppointmentAll()
        {
            var appointment = await _appointmentService.GetAppointmentsAllAsync();
            if (appointment == null || appointment.Count==0)
            {
                return Ok(new List<AppointmentDTO>());
                
            }
            return Ok(appointment);
        }

        [HttpGet]
        [Route("user/{userId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetAppointmentsByUser([FromRoute] int userId)
        {
            var appointments = await _appointmentService.GetAppointmentsByUserAsync(userId);
            if (appointments == null || appointments.Count == 0)
            {
                return BadRequest(new { Error = "Invalid UserId" });
            }
            return Ok(appointments);
        }

        [HttpPost]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentDTO appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest(new { Error = "Invalid Request" });
            }

            await _appointmentService.AddAppointmentAsync(appointmentDto);
            return CreatedAtAction(nameof(GetAppointment), new { appointmentId = appointmentDto.AppointmentId }, appointmentDto);
        }

        [HttpPut]
        [Route("{appointmentId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] int appointmentId,[FromBody] AppointmentDTO appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest(new { Error = "Invalid request" });
            }

            var result = await _appointmentService.UpdateAppointmentAsync(appointmentId,appointmentDto);

            if(!result.Item1)
            {
                return BadRequest(new { Error = result.Item2 });
            }

            return Ok(appointmentDto);
        }

        [HttpDelete]
        [Route("{appointmentId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int appointmentId)
        {
            await _appointmentService.DeleteAppointmentAsync(appointmentId);
            return NoContent();
        }

        [HttpGet]
        [Route("status")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetAppointmentStatus()
        {
            var appointmentStatus = await _appointmentStatusService.GetAllAppointmentStatusesAsync();
            if (appointmentStatus == null)
            {
                return NotFound();
            }
            return Ok(appointmentStatus);
        }
    }
}
