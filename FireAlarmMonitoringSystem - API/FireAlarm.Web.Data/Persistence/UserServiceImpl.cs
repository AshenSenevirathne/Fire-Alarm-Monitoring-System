using FireAlarm.Web.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   UserServiceImpl
 * @Description :   UserServiceImpl class implement the all methods in
 *                  IUserService interface
*/

namespace FireAlarm.Web.Data.Persistence
{
    public class UserServiceImpl : IUserService
    {
        // Create FireAlarmDbContext object
        private readonly FireAlarmDbContext _context;

        public UserServiceImpl() { }

        // Constructor
        public UserServiceImpl(FireAlarmDbContext context) 
        {
            _context = context;
        }

        // Get mobile no and email list
        public async Task<ApiResult> GetUserEmailAndMobileList()
        {
            // Get email list
            var emailList = await _context.Users.Select(user => user.userEmail).ToListAsync();
            // Get mobile no list
            var mobileList = await _context.Users.Select(user => user.userMobileNo).ToListAsync();

            // Create result object
            var resultObj = new
            {
                email = emailList,
                mobile = mobileList
            };

            // return the result object
            return new ApiResult { STATUS = true, DATA = resultObj };
        }

        public async Task<User> SignIn(User user)
        {
            // Check any user exist given username and password
            User loginUser = await _context.Users.FirstOrDefaultAsync(
                dbUser => dbUser.userEmail.Equals(user.userEmail) && dbUser.userPassword.Equals(user.userPassword)
            );

            // Check user is null or not
            if (loginUser == null)
                return null;

            // Get user role
            loginUser.userRole = await _context.UserRoles.FirstOrDefaultAsync(userRole => userRole.roleId == loginUser.userRoleId);

            // return user
            return loginUser;
        }
    }
}
