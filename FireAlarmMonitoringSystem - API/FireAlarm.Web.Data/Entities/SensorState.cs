using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FireAlarm.Web.Data.Entities
{
    public class SensorState
    {
        [Key]
        [JsonProperty("statusId")]
        public int statusId { get; set; }
        [JsonProperty("smokeLevel")]
        public int smokeLevel { get; set; }
        [JsonProperty("coLevel")]
        public int coLevel { get; set; }
        [JsonProperty("sensorId")]
        public int sensorId { get; set; }
        public SensorDetails sensorDetails { get; set; }
    }
}
