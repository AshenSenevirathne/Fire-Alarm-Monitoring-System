using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FireAlarm.Web.Data.Entities;
using FireAlarm.Web.Data.Persistence;
using Microsoft.AspNetCore.Authorization;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   SensorController
 * @Description :   SensorController class inherite from the ControllerBase class. SensorController class basically handle the
 *                  all endpoints related to the Sensors.
*/

namespace FireAlarm.Web.API.Controllers
{
    // Set the API URL Path - api/SensorController
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        // Create object from FireAlarmDbContext class
        private readonly FireAlarmDbContext _context;
        // Create object from ISensorService - ISensorService handle the all CRUD operations related to the sensors
        private readonly ISensorService _sensorService;

        // Constructor
        public SensorController(FireAlarmDbContext context, ISensorService sensorService) 
        {
            _context = context;
            _sensorService = sensorService;
        }

        // Used to get all registered sensors in API.
        // Define API URL Path - api/SensorController/GetSensorDetails (GET)
        // Call the GetSensorDetails method inside ISensorService interface
        // Return the All registered sensor details
        [HttpGet("GetSensorDetails")]
        public async Task<ApiResult> GetSensorDetails()
        {
            return await _sensorService.GetSensorDetails();
        }

        // Used to register new sensor
        // Define API URL Path - api/SensorController/RegisterSensor (POST)
        // Call the RegisterSensor method inside ISensorService interface
        // This is a authorize method. Only "ADMIN" users can acess the this method.
        // Return sucessfully registered or not
        [Authorize(Roles = "ADMIN")]
        [HttpPost("RegisterSensor")]
        public async Task<ApiResult> RegisterSensor(SensorDetails sensorDetails)
        {
            return await _sensorService.RegisterSensor(sensorDetails);
        }

        // Used to edit the sensor
        // Define API URL Path - api/SensorController/EditSensor (PUT)
        // Call the EditSensor method inside ISensorService interface
        // This is a authorize method. Only "ADMIN" users can acess the this method.
        // Return sucessfully edited or not
        [Authorize(Roles = "ADMIN")]
        [HttpPut("EditSensor")]
        public async Task<ApiResult> EditSensor(SensorDetails sensorDetails)
        {
            return await _sensorService.EditSensor(sensorDetails);
        }

        // Used to delete the sensor
        // Define API URL Path - api/SensorController/DeleteSensor/{SensorId} (DELETE)
        // Call the DeleteSensor method inside ISensorService interface
        // This is a authorize method. Only "ADMIN" users can acess the this method.
        // Return sucessfully deleted or not
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("DeleteSensor/{sensorId}")]
        public async Task<ApiResult> DeleteSensor(int sensorId)
        {
            return await _sensorService.DeleteSensor(sensorId);
        }

        // Used to update the sensor state
        // Define API URL Path - api/SensorController/SetSensorState (POST)
        // Call the SetSensorState method inside ISensorService interface
        // Return the sensor state sucessfully updated or not
        [HttpPost("SetSensorState")]
        public async Task<ApiResult> SetSensorState(SensorDetails sensorState)
        {
            return await _sensorService.SetSensorState(sensorState);
        }
    }
}