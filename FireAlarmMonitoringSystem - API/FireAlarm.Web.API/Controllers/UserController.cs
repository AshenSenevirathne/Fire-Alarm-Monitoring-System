using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FireAlarm.Web.Data.Entities;
using FireAlarm.Web.Data.Persistence;
using FireAlarm.Web.API.Services;
using Microsoft.Extensions.Configuration;

namespace FireAlarm.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FireAlarmDbContext _context;
        private readonly IUserService _userService;
        private IConfiguration _configuration;

        public UserController(FireAlarmDbContext context, IUserService userService, IConfiguration configuration)
        {
            _context = context;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public async Task<ApiResult> SignIn(User user)
        {
            User loginUser = await _userService.SignIn(user);
            Authentication authentication = new Authentication(_configuration);
            return authentication.GetToken(loginUser);
        }

        [HttpGet("GetUserEmailMobile")]
        public async Task<ApiResult> GetUserEmailMobile()
        {
            return await _userService.GetUserEmailAndMobileList();
        }
    }
}