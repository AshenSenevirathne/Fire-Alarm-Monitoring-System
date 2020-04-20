using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarm.Web.Data.Persistence
{
    public interface IUserService
    {
        Task<ApiResult> SignIn(User user);
    }
}
