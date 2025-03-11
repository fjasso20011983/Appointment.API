﻿using System;
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

        public AppointmentController(IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("{appointmentId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetAppointment([FromRoute] int appointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpGet]
        [Route("user/{userId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetAppointmentsByUser([FromRoute] int userId)
        {
            var appointments = await _appointmentService.GetAppointmentsByUserAsync(userId);
            return Ok(appointments);
        }

        [HttpPost]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentDTO appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest();
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
                return BadRequest();
            }

            await _appointmentService.UpdateAppointmentAsync(appointmentId,appointmentDto);
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
    }
}
