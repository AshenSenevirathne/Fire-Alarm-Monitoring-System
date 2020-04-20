using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireAlarm.Web.Data.Entities
{
    public class ApiResult
    {
        [JsonProperty("STATUS")]
        public bool STATUS { get; set; }
        [JsonProperty("DATA")]
        public object DATA { get; set; }
    }
}
