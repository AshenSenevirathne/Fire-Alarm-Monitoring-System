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

        public async Task<bool> DeleteSensor(int sensorId)
        {
            SensorDetails sensorDetails = await _context.SensorDetails.FindAsync(sensorId);
            if (sensorDetails == null)
                return false;

            _context.SensorDetails.Remove(sensorDetails);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditSensor(SensorDetails sensorDetails)
        {
            SensorDetails dbSensorObj = await _context.SensorDetails.FindAsync(sensorDetails.sensorId);
            if (dbSensorObj == null || sensorDetails == null)
                return false;

            dbSensorObj.sensorName = sensorDetails.sensorName;
            dbSensorObj.floorNo = sensorDetails.floorNo;
            dbSensorObj.roomNo = sensorDetails.roomNo;
            dbSensorObj.sensorStatus = sensorDetails.sensorStatus;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SensorDetails>> GetSensorDetails()
        {
            return await _context.SensorDetails.ToListAsync();
        }

        public async Task<List<SensorState>> GetSensorState()
        {
            return await _context.SensorState.ToListAsync();
        }

        public async Task<bool> RegisterSensor(SensorDetails sensorDetails)
        {
            if(sensorDetails != null)
            {
                await _context.AddAsync(sensorDetails);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException dbUpdateEx)
                {
                    throw new Exception("Error saving data", dbUpdateEx);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error happen", ex);
                }
                return true;
            }
            return false;
        }

        public async Task<bool> SetSensorState(SensorState sensorState)
        {
            if(sensorState != null)
            {
                await _context.AddAsync(sensorState);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    throw new Exception("Error saving data", ex);
                }
                return true;
            }
            return false;
        }
    }
}
