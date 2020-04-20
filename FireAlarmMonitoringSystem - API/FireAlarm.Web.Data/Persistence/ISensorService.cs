using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarm.Web.Data.Persistence
{
    public interface ISensorService
    {
        Task<List<SensorDetails>> GetSensorDetails();
        Task<List<SensorState>> GetSensorState();
        Task<bool> RegisterSensor(SensorDetails sensorDetails);
        Task<bool> EditSensor(SensorDetails sensorDetails);
        Task<bool> DeleteSensor(int sensorId);
        Task<bool> SetSensorState(SensorState sensorState);
    }
}
