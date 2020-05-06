using System;
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

        [HttpGet("GetSensorDetails")]
        public async Task<ApiResult> GetSensorDetails()
        {
            return await _sensorService.GetSensorDetails();
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

        [HttpGet("GetSensors")]
        public async Task<ApiResult> GetSensors()
        {
            return await _sensorService.GetSensors();
        }

        [HttpPost("SetSensorState")]
        public async Task<ApiResult> SetSensorState(SensorDetails sensorState)
        {
            return await _sensorService.SetSensorState(sensorState);
        }
    }
}