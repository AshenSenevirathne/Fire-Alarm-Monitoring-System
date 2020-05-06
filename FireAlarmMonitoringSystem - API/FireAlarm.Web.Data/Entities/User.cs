using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   User
 * @Description :   User class store the all properties of the Users
*/

namespace FireAlarm.Web.Data.Entities
{
    public class User
    {
        [Key]
        [JsonProperty("userId")]
        public int userId { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }
        [JsonProperty("userPassword")]
        public string userPassword { get; set; }
        [JsonProperty("userEmail")]
        public string userEmail { get; set; }
        [JsonProperty("userMobileNo")]
        public string userMobileNo { get; set; }
        public int userRoleId { get; set; }
        public UserRole userRole { get; set; }
    }
}
