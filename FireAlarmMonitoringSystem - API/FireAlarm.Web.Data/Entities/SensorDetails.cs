using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FireAlarm.Web.Data.Entities
{
    public class SensorDetails
    {
        [Key]
        [JsonProperty("sensorId")]
        public int sensorId { get; set; }
        [JsonProperty("sensorName")]
        public string sensorName { get; set; }
        [JsonProperty("floorNo")]
        public string floorNo { get; set; }
        [JsonProperty("roomNo")]
        public string roomNo { get; set; }
        [JsonProperty("sensorStatus")]
        public string sensorStatus { get; set; }
        [JsonProperty("sensorRemark")]
        public string sensorRemark { get; set; }
        [JsonProperty("smokeLevel")]
        public int smokeLevel { get; set; }
        [JsonProperty("coLevel")]
        public int coLevel { get; set; }
    }
}
