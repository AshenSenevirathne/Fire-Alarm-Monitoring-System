using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarm.Web.Data.Persistence
{
    public class UserServiceImpl : IUserService
    {
        public Task<User> SignIn(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }
    }
}
