using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   UserRole
 * @Description :   UserRole class store the all properties of the User Roles
*/

namespace FireAlarm.Web.Data.Entities
{
    public class UserRole
    {
        [Key]
        [JsonProperty("roleId")]
        public int roleId { get; set; }
        [JsonProperty("roleDescription")]
        public string roleDescription { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
