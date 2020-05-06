using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   ApiResult
 * @Description :   ApiResult class handle the api return object.
 *                  Every response from API send the ApiResult object.
 *                  ApiResult has two property.
 *                      * status - this is a boolean values and if it is true that mean response come without any error.
 *                                  but if it is false that means error happe in the api.
 *                      * data - data property contains the details about response. if status true data property contains 
 *                              the result and if status false data property contains the error message.
*/


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
