using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using appmvc.Data;
using appmvc.AuthApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace appmvc
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
            services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllersWithViews();

            #region Auth
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;                                     // ���������� email
                options.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz";
            }) // ���������� �������)
                .AddEntityFrameworkStores<PhoneBookContext>();
                //.AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6; // ����������� ���������� ������ � ������
                options.Lockout.MaxFailedAccessAttempts = 10; // ���������� ������� � ����������
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // ������������ Cookie � ����� ������������� �� ��� �������� �����������
                options.Cookie.HttpOnly = true;
                //options.Cookie.Expiration = TimeSpan.FromMinutes(30);
                //options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            }
    }
}
