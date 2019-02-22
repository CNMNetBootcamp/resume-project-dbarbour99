using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume2.Data;
using Resume2.Models;
using Resume2.Services;
using System;

namespace Resume2
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
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddDbContext<Resume2Context>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("Resume2Connection")));

      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      //services.AddAuthentication().AddFacebook(y => {
      //  y.ClientId = Configuration["Facebook:AppId"];
      //  y.ClientSecret = Configuration["Facebook:AppSecret"];
      //});

      //services.AddAuthentication().AddGoogle(y => {
      //  y.ClientId = Configuration["Google:client_id"];
      //  y.ClientSecret = Configuration["Google:client_secret"];
      //});


      services.Configure<IdentityOptions>(options =>
      {
        //password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredUniqueChars = 6;

        //lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
        options.Lockout.MaxFailedAccessAttempts = 10;
        options.Lockout.AllowedForNewUsers = true;

        //User settings
        options.User.RequireUniqueEmail = true;
      });

      services.ConfigureApplicationCookie(options =>
      {
        //cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/AccountAccessDenied";
        options.SlidingExpiration = true;

      });

      // Add application services.
      services.AddTransient<IEmailSender, EmailSender>();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
        if (env.IsDevelopment())
        {
          app.UseBrowserLink();
          app.UseDeveloperExceptionPage();
          app.UseDatabaseErrorPage();
        }
        else
        {
          app.UseExceptionHandler("/Home/Error");
        }

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
