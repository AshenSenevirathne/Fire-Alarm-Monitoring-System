using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FireAlarm.Web.Data.Entities;
using FireAlarm.Web.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FireAlarm.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS
            services.AddCors();
            services.AddControllers();

            // Validate the token of each api request
            // Create the symmetric key using secret key 
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Token:Secret")));
            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        // Set valid issuer
                        ValidIssuer = Configuration.GetValue<string>("Token:Issuer"),
                        // Set valid audience
                        ValidAudience = Configuration.GetValue<string>("Token:Audiance"),
                        // Set symmetric key
                        IssuerSigningKey = symmetricKey
                    };
                });

            // Set Sql connection to the FireAlarmDbContext classs
            services.AddDbContext<FireAlarmDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDbContext")));
            //  Set ISensorService and IUserService
            services.AddScoped<ISensorService,SensorServiceImpl>();
            services.AddScoped<IUserService,UserServiceImpl>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable CORS
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            // Set Authentication
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
