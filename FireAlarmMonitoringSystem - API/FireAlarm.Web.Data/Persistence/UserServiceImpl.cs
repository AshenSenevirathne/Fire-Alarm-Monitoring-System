using FireAlarm.Web.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<ApiResult> SignIn(User user)
        {
            User loginUser = await _context.Users.FirstOrDefaultAsync(
                dbUser => dbUser.userName.Equals(user.userName) && dbUser.userPassword.Equals(user.userPassword)
            );

            if(loginUser == null)
                return new ApiResult { STATUS = false, DATA = "There is no user related to the user id" };

            var resultObj = new
            {
                userId = loginUser.userId,
                userName = loginUser.userName,
                token = "123456789ABCDEFGHIJKLMNOPQRS"
                
            };
            return new ApiResult { STATUS = true, DATA = resultObj };
        }
    }
}
