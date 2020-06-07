using System.Text;
using System.Data;
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
using TravelHelper.Infrastructure.Services;
using TravelHelper.Infrastructure.Repositories;
using TravelHelper.Core.Repositories;
using TravelHelper.Infrastructure.Mappers;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using TravelHelper.Infrastructure.IoC.Modules;
using TravelHelper.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TravelHelper.Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using TravelHelper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelHelper.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();
            services.AddCors();
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IEmailSender,EmailSender>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>{
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey= true,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                                ValidateIssuer= false,
                                ValidateAudience= false
                            };
                        });
        // Build an intermediate service provider
         //   var sp = services.BuildServiceProvider();

        // Resolve the services from the service provider
           /* var jwtSettings = sp.GetService<JwtSettings>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(cfg => {
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {   
                            ValidIssuer = "http://localhost:5001",
                            ValidateAudience = false,
                           // ValidateLifetime = true,
                           
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""))

                    };


                }
 
                
                );*/
                // configure DI for application services
           
        }
        
    
        public void ConfigureContainer(ContainerBuilder builder)
        {
          
            builder.RegisterModule(new ContainerModule(Configuration));
     
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void  Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }           
            app.UseHttpsRedirection();
            app.UseRouting();         
            app.UseAuthorization();
            app.UseAuthentication();  
            app.UseCors(x=>x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());

        }
    }
}
