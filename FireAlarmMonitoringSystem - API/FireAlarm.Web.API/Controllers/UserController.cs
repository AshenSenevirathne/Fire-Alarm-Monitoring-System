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

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   UserController
 * @Description :   UserController class inherite from the ControllerBase class. UserController class basically handle the
 *                  all endpoints related to the Users.
*/

namespace FireAlarm.Web.API.Controllers
{
    // Set the API URL Path - api/UserController
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Create object from FireAlarmDbContext class
        private readonly FireAlarmDbContext _context;
        // Create object from IUserService - IUserService handle the all CRUD operations related to the users
        private readonly IUserService _userService;
        // Configuration object
        private IConfiguration _configuration;

        // Constructor
        public UserController(FireAlarmDbContext context, IUserService userService, IConfiguration configuration)
        {
            _context = context;
            _userService = userService;
            _configuration = configuration;
        }

        // Used to signin to the system
        // Define API URL Path - api/UserController/SignIn (POST)
        // Call the SignIn method inside IUserService interface
        // Return the User object if sucessfully registered
        [HttpPost("SignIn")]
        public async Task<ApiResult> SignIn(User user)
        {
            User loginUser = await _userService.SignIn(user);
            Authentication authentication = new Authentication(_configuration);
            return authentication.GetToken(loginUser);
        }

        // Used to get email list and mobile list of all users
        // Define API URL Path - api/UserController/GetUserEmailMobile (GET)
        // Call the GetUserEmailMobile method inside IUserService interface
        // Return the Users email and mobile list
        [HttpGet("GetUserEmailMobile")]
        public async Task<ApiResult> GetUserEmailMobile()
        {
            return await _userService.GetUserEmailAndMobileList();
        }
    }
}