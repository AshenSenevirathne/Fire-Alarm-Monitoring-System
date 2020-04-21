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
            services.AddControllers();

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Token:Secret")));
            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration.GetValue<string>("Token:Issuer"),
                        ValidAudience = Configuration.GetValue<string>("Token:Audiance"),
                        IssuerSigningKey = symmetricKey
                    };
                });

            services.AddDbContext<FireAlarmDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDbContext")));
            services.AddScoped<ISensorService,SensorServiceImpl>();
            services.AddScoped<IUserService,UserServiceImpl>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
