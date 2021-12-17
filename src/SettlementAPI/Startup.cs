using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SettlementAPI.Configurations;
using SettlementAPI.Core;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Core.Repositories;
using SettlementAPI.Entities;
using SettlementAPI.Services;
using System.Security.Claims;

namespace SettlementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SettlementDbContext>(o => 
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SettlementAPI", Version = "v1" });
            });

            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);


            services.AddAutoMapper(typeof(MapperInitilizer));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<ISettlementService, SettlementService>();
            services.AddScoped<IFriendService, FriendService>();

            services.AddControllers().AddNewtonsoftJson(op =>
                op.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp =>
            {
                var identityOptions = new Options.IdentityOptions();
                var httpContext = sp.GetService<IHttpContextAccessor>().HttpContext;
                if (httpContext.User.Identity.IsAuthenticated)
                {
                    identityOptions.UserMail = httpContext.User.FindFirst(ClaimTypes.Name).Value;
                }
                return identityOptions;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SettlementAPI v1"));
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
