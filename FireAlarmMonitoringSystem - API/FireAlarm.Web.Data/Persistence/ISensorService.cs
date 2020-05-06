using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   ISensorService
 * @Description :   ISensorService interface contains the all methods 
 *                  related to the sensors
*/


namespace FireAlarm.Web.Data.Persistence
{
    public interface ISensorService
    {
        // To Get All Sensors
        Task<ApiResult> GetSensorDetails();
        // To Register New Sensor
        Task<ApiResult> RegisterSensor(SensorDetails sensorDetails);
        // To Edit Exising Sensor
        Task<ApiResult> EditSensor(SensorDetails sensorDetails);
        // To Delete Sensor
        Task<ApiResult> DeleteSensor(int sensorId);
        // To Update The Sensor State
        Task<ApiResult> SetSensorState(SensorDetails sensorState);
    }
}
