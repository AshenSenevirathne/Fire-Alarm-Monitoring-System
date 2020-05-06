using FireAlarm.Web.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FireAlarm.Web.Data.Persistence
{
    public class UserServiceImpl : IUserService
    {
        private readonly FireAlarmDbContext _context;

        public UserServiceImpl() { }

        public UserServiceImpl(FireAlarmDbContext context) 
        {
            _context = context;
        }

        public async Task<ApiResult> GetUserEmailAndMobileList()
        {
            var emailList = await _context.Users.Select(user => user.userEmail).ToListAsync();
            var mobileList = await _context.Users.Select(user => user.userMobileNo).ToListAsync();

            var resultObj = new
            {
                email = emailList,
                mobile = mobileList
            };

            return new ApiResult { STATUS = true, DATA = resultObj };
        }

        public async Task<User> SignIn(User user)
        {
            User loginUser = await _context.Users.FirstOrDefaultAsync(
                dbUser => dbUser.userEmail.Equals(user.userEmail) && dbUser.userPassword.Equals(user.userPassword)
            );

            if (loginUser == null)
                return null;

            loginUser.userRole = await _context.UserRoles.FirstOrDefaultAsync(userRole => userRole.roleId == loginUser.userRoleId);
            return loginUser;
        }
    }
}
