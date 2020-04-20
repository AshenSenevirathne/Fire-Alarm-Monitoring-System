using Microsoft.EntityFrameworkCore;
using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarm.Web.Data.Persistence
{
    public class SensorServiceImpl : ISensorService
    {
        private readonly FireAlarmDbContext _context;

        public SensorServiceImpl() { }
        public SensorServiceImpl(FireAlarmDbContext context) 
        {
            _context = context;
        }

        public async Task<ApiResult> DeleteSensor(int sensorId)
        {
            SensorDetails sensorDetails = await _context.SensorDetails.FindAsync(sensorId);
            if (sensorDetails == null)
                return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };

            _context.SensorDetails.Remove(sensorDetails);
            await _context.SaveChangesAsync();
            return new ApiResult { STATUS = true, DATA = "Sucessfully deleted - " + sensorId };
        }

        public async Task<ApiResult> EditSensor(SensorDetails sensorDetails)
        {
            SensorDetails dbSensorObj = await _context.SensorDetails.FindAsync(sensorDetails.sensorId);
            if (dbSensorObj == null || sensorDetails == null)
                return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };

            dbSensorObj.sensorName = sensorDetails.sensorName;
            dbSensorObj.floorNo = sensorDetails.floorNo;
            dbSensorObj.roomNo = sensorDetails.roomNo;
            dbSensorObj.sensorStatus = sensorDetails.sensorStatus;

            await _context.SaveChangesAsync();
            return new ApiResult { STATUS = true, DATA = "Sucessfully edited - " + sensorDetails.sensorId };
        }

        public async Task<ApiResult> GetSensorDetails()
        {
            var resultObj = await _context.SensorDetails.ToListAsync();
            return new ApiResult { STATUS = true, DATA = resultObj };
        }

        public async Task<ApiResult> GetSensorState()
        {
            var resultObj =  await _context.SensorState.ToListAsync();
            return new ApiResult { STATUS = true, DATA = resultObj };
        }

        public async Task<ApiResult> RegisterSensor(SensorDetails sensorDetails)
        {
            if(sensorDetails != null)
            {
                await _context.AddAsync(sensorDetails);
                try
                {
                    await _context.SaveChangesAsync();
                    return new ApiResult { STATUS = true, DATA = "Sucessfully saved - " + sensorDetails.sensorId };
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
            return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };
        }

        public async Task<ApiResult> SetSensorState(SensorState sensorState)
        {
            if(sensorState != null)
            {
                await _context.AddAsync(sensorState);
                try
                {
                    await _context.SaveChangesAsync();
                    return new ApiResult { STATUS = true, DATA = "Sucessfully saved - " + sensorState.sensorId };
                }
                catch(Exception ex)
                {
                    return new ApiResult { STATUS = false, DATA = "Error saving data - " + ex };
                }
            }
            return new ApiResult { STATUS = false, DATA = "There is no sensor related to the sensor id" };
        }
    }
}
