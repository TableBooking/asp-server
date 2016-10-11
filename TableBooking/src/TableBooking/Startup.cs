using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TableBooking.Data;
using TableBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace TableBooking
{
    public class Startup
    {
	    public Startup(IHostingEnvironment env)
	    {
			var builder = new ConfigurationBuilder()
			   .SetBasePath(env.ContentRootPath)
			   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
			   .AddEnvironmentVariables();
			Configuration = builder.Build();
		}

	    private IConfigurationRoot Configuration { get; }

	    public void ConfigureServices(IServiceCollection services)
	    {
		    var connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection))
				    .AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connection));

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<IdentityOptions>(options =>
			{
				// Password settings
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = false;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
				options.Lockout.MaxFailedAccessAttempts = 10;

				// Cookie settings
				options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
				options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
				options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOff";
			});

			services.AddMvc();
		}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        app.UseIdentity();

			app.UseMvc(m => {
				m.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" });
			});
		}
    }
}
