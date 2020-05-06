using FireAlarm.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   IUserService
 * @Description :   IUserService interface contains the all methods 
 *                  related to the users
*/

namespace FireAlarm.Web.Data.Persistence
{
    public interface IUserService
    {
        // To Signin To The Users
        Task<User> SignIn(User user);
        // To Get All Mobiles No And Emails List
        Task<ApiResult> GetUserEmailAndMobileList();
    }
}
