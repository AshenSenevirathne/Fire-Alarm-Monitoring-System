﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FireAlarm.Web.Data.Entities;
using FireAlarm.Web.Data.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace FireAlarm.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly FireAlarmDbContext _context;
        private readonly ISensorService _sensorService;

        public SensorController(FireAlarmDbContext context, ISensorService sensorService) 
        {
            _context = context;
            _sensorService = sensorService;
        }

        [Authorize]
        [HttpGet("GetSensorDetails")]
        public async Task<ApiResult> GetSensorDetails()
        {
            return await _sensorService.GetSensorDetails();
        }

        [Authorize]
        [HttpGet("GetSensorState")]
        public async Task<ApiResult> GetSensorState()
        {
            return await _sensorService.GetSensorState();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("RegisterSensor")]
        public async Task<ApiResult> RegisterSensor(SensorDetails sensorDetails)
        {
            return await _sensorService.RegisterSensor(sensorDetails);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("EditSensor")]
        public async Task<ApiResult> EditSensor(SensorDetails sensorDetails)
        {
            return await _sensorService.EditSensor(sensorDetails);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("DeleteSensor/{sensorId}")]
        public async Task<ApiResult> DeleteSensor(int sensorId)
        {
            return await _sensorService.DeleteSensor(sensorId);
        }

        [HttpPost("SetSensorState")]
        public async Task<ApiResult> SetSensorState(SensorState sensorState)
        {
            return await _sensorService.SetSensorState(sensorState);
        }
    }
}