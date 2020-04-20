using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FireAlarm.Web.Data.Entities;
using FireAlarm.Web.Data.Persistence;

namespace FireAlarm.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FireAlarmDbContext _context;
        private readonly IUserService _userService;

        public UserController(FireAlarmDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("SignIn")]
        public async Task<ApiResult> SignIn(User user)
        {
            return await _userService.SignIn(user);
        }
    }
}