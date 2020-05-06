using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarm.Web.Data.Persistence
{
    public interface ISensorService
    {
        Task<ApiResult> GetSensorDetails();
        Task<ApiResult> RegisterSensor(SensorDetails sensorDetails);
        Task<ApiResult> EditSensor(SensorDetails sensorDetails);
        Task<ApiResult> DeleteSensor(int sensorId);
        Task<ApiResult> SetSensorState(SensorDetails sensorState);
    }
}
