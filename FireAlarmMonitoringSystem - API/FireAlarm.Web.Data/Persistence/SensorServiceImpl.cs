using Microsoft.EntityFrameworkCore;
using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   SensorServiceImpl
 * @Description :   SensorServiceImpl class implement the all methods in
 *                  ISensorService interface
*/

namespace FireAlarm.Web.Data.Persistence
{
    public class SensorServiceImpl : ISensorService
    {
        // Create FireAlarmDbContext object
        private readonly FireAlarmDbContext _context;

        // Constructor
        public SensorServiceImpl() { }
        public SensorServiceImpl(FireAlarmDbContext context) 
        {
            _context = context;
        }

        // Delete sensor
        public async Task<ApiResult> DeleteSensor(int sensorId)
        {
            // First get a sensor from database by passing sensor id
            SensorDetails sensorDetails = await _context.SensorDetails.FindAsync(sensorId);
            // If sensorDetails is null pass error
            if (sensorDetails == null)
                return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };

            // Otherwise delete the sensor object from database and save changes in database.
            _context.SensorDetails.Remove(sensorDetails);
            await _context.SaveChangesAsync();
            
            // return the result object
            return new ApiResult { STATUS = true, DATA = "Sucessfully deleted - sensor id : " + sensorId };
        }

        // Edit sensor
        public async Task<ApiResult> EditSensor(SensorDetails sensorDetails)
        {
            // First get a sensor from database by passing sensor id
            SensorDetails dbSensorObj = await _context.SensorDetails.FindAsync(sensorDetails.sensorId);
            // If sensorDetails is null pass error
            if (dbSensorObj == null || sensorDetails == null)
                return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };

            // Update the properties of sensor object
            dbSensorObj.sensorName = sensorDetails.sensorName;
            dbSensorObj.floorNo = sensorDetails.floorNo;
            dbSensorObj.roomNo = sensorDetails.roomNo;
            dbSensorObj.sensorStatus = sensorDetails.sensorStatus;
            dbSensorObj.sensorRemark = sensorDetails.sensorRemark;

            // Save the changes in database
            await _context.SaveChangesAsync();
            // return the result object
            return new ApiResult { STATUS = true, DATA = "Sucessfully edited - sensor id : " + sensorDetails.sensorId };
        }

        // Get sensors
        public async Task<ApiResult> GetSensorDetails()
        {
            // Create a result object using Sensor Details
            // Get sensor details if sensor status equals to the "A"
            var resultObj = await _context.SensorDetails.Where(sensorDetails => sensorDetails.sensorStatus.Equals("A"))
                .Select(sensorObj => new
                {
                    sensorId = sensorObj.sensorId,
                    sensorName = sensorObj.sensorName,
                    floorNo = sensorObj.floorNo,
                    roomNo = sensorObj.roomNo,
                    sensorStatus = sensorObj.sensorStatus,
                    smokeLevel = sensorObj.smokeLevel,
                    co2Level = sensorObj.coLevel
                }
            ).ToListAsync();
            // return the result object
            return new ApiResult { STATUS = true, DATA = resultObj };
        }

        // Register sensor
        public async Task<ApiResult> RegisterSensor(SensorDetails sensorDetails)
        {
            // Check sensorDetails object is null or not
            if (sensorDetails != null)
            {
                // Save the Sensor object
                await _context.AddAsync(sensorDetails);
                try
                {
                    // Save the changes in database
                    await _context.SaveChangesAsync();
                    // return the result object
                    return new ApiResult { STATUS = true, DATA = "Sucessfully saved - sensor id : " + sensorDetails.sensorId };
                }
                catch(DbUpdateException dbUpdateEx)
                {
                    return new ApiResult { STATUS = false, DATA = "Error saving data - " + dbUpdateEx };
                }
                catch(Exception ex)
                {
                    return new ApiResult { STATUS = false, DATA = "Error saving data - " + ex };
                }
            }

            // return the result object
            return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };
        }

        // Set sensor state
        public async Task<ApiResult> SetSensorState(SensorDetails sensorState)
        {
            // Check sensorState object is null or not
            if (sensorState != null)
            {
                // Get a sensor from database by passing sensor id
                SensorDetails dbSensorObj = await _context.SensorDetails.FindAsync(sensorState.sensorId);
                // If sensorDetails is null pass error
                if (dbSensorObj == null || sensorState == null)
                    return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };

                // Update the sensor smoke and co2 values of sensor object
                dbSensorObj.smokeLevel = sensorState.smokeLevel;
                dbSensorObj.coLevel = sensorState.coLevel;

                // Save the changes in database
                await _context.SaveChangesAsync();
                // return the result object
                return new ApiResult { STATUS = true, DATA = "Sucessfully updated - sensor id : " + sensorState.sensorId };
            }
            return new ApiResult { STATUS = false, DATA = "Please enter sensor details to pass object" };
        }
    }
}
