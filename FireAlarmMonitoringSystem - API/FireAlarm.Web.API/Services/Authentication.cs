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

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   Authentication
 * @Description :   Basically Generate the Token and return to the users
*/

namespace FireAlarm.Web.API.Services
{
    public class Authentication
    {
        // Define properties of Authentication class
        private readonly IConfiguration Configuration;
        private string SecretKey { get; set; }
        private string Issuer { get; set; }
        private string Audiance { get; set; }

        public Authentication(IConfiguration configuration) 
        {
            Configuration = configuration;
            SecretKey = Configuration.GetValue<string>("Token:Secret");     // Get the Secret key from the appsettings.json
            Issuer = Configuration.GetValue<string>("Token:Issuer");        // Get the Issuer value the appsettings.json
            Audiance = Configuration.GetValue<string>("Token:Audiance");    // Get the Audiance value from the appsettings.json
        }

        // Check user details and generate the token
        public ApiResult GetToken(User loginUser)
        {
            // Check loginUser is null. If it is null that means there is no user related to the user credintial
            if (loginUser == null)
                return new ApiResult { STATUS = false, DATA = "There is no user related to the user credintial" };

            // If loginUser is not null assign the user claims using loginUser object
            var claims = new[]
            {
                new Claim("userId", loginUser.userId.ToString()),               // Set user id
                new Claim(ClaimTypes.Role, loginUser.userRole.roleDescription)  // Set user role
            };

            // SecretKey convert to the bytes
            var secretBytes = Encoding.UTF8.GetBytes(SecretKey);
            // Create the SymmetricSecurityKey using secretBytes
            var symmetricKey = new SymmetricSecurityKey(secretBytes);
            // Create the SigningCredentials object by passing symmetric key and the encrypted algorithems
            var signInCredintial = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            // Create the token object
            var token = new JwtSecurityToken(
                Issuer,                             // Set Issuer
                Audiance,                           // Set Audiance
                claims,                             // Set claims
                notBefore: DateTime.Now,            // Set token assign time
                expires: DateTime.Now.AddHours(1),  // Set token expire time
                signInCredintial                    // Set SigningCredentials
            );

            // Create the return object
            // Pass the user information and the token
            var resultObj = new
            {
                userId = loginUser.userId,
                userName = loginUser.userName,
                token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
                userMobile = loginUser.userMobileNo,
                userEmail = loginUser.userEmail,
                userRole = loginUser.userRole.roleDescription
            };

            // Pass the result object
            return new ApiResult { STATUS = true, DATA = resultObj };
        }
    }
}
