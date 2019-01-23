using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InternetForum.Models;
using InternetForum.Services;
using InternetForum.DL;
using InternetForum.DL.Entities;
using ReflectionIT.Mvc.Paging;

namespace InternetForum
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
			services.AddDbContext<InternetForumDbContext>(options =>
				options
					.UseLazyLoadingProxies()
					.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<InternetForumDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddFacebook(facebookOptions =>
				{
					facebookOptions.AppId = "1955015674620090";
					facebookOptions.AppSecret = "0354fd7b50e4a85583e4016b5b065418";
				});

			// Přidání UnitOfWork do Service Provideru
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			services.AddPaging();

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider,
			UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			// Vložení defaultních dat do databáze...
			DatabaseInitializer.Seed(userManager, roleManager, serviceProvider.GetRequiredService<InternetForumDbContext>());

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
