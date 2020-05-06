using FireAlarm.Web.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FireAlarm.Web.API.Services
{
    public class Authentication
    {
        private readonly IConfiguration Configuration;
        private string SecretKey { get; set; }
        private string Issuer { get; set; }
        private string Audiance { get; set; }

        public Authentication(IConfiguration configuration) 
        {
            Configuration = configuration;
            SecretKey = Configuration.GetValue<string>("Token:Secret");
            Issuer = Configuration.GetValue<string>("Token:Issuer");
            Audiance = Configuration.GetValue<string>("Token:Audiance");
        }
        public ApiResult GetToken(User loginUser)
        {
            if(loginUser == null)
                return new ApiResult { STATUS = false, DATA = "There is no user related to the user credintial" };

            var claims = new[]
            {
                new Claim("userId", loginUser.userId.ToString()),
                new Claim(ClaimTypes.Role, loginUser.userRole.roleDescription)
            };

            var secretBytes = Encoding.UTF8.GetBytes(SecretKey);
            var symmetricKey = new SymmetricSecurityKey(secretBytes);
            var signInCredintial = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Issuer,
                Audiance,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signInCredintial
            );

            var resultObj = new
            {
                userId = loginUser.userId,
                userName = loginUser.userName,
                token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
                userMobile = loginUser.userMobileNo,
                userEmail = loginUser.userEmail,
                userRole = loginUser.userRole.roleDescription
            };

            return new ApiResult { STATUS = true, DATA = resultObj };
        }
    }
}
