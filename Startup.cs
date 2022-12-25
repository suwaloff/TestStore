using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Data;

namespace TestStore
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
            // �������� ������ ����������� �� ����� ������������
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            // ��������� �������� ApplicationDBContext � �������� ������� � ����������
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpContextAccessor();
            
            services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromMinutes(10);
                Options.Cookie.HttpOnly = true;
                Options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //��������� � ���������������� �������� �������������� ����������� ...

            if (env.IsDevelopment())     //  ����� ������� ���������� 
            {
                app.UseDeveloperExceptionPage();  // ����������� ��������� ������� ���������� 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");   // �������� ��� ������������ � ������� 
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();                // ������� �� ���������� ���������� 

            app.UseStaticFiles();                   //  ������ � ����������� ������ 

            app.UseRouting();                     // ��������� �������������  

            app.UseAuthorization();              //  ����������� 

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(        
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                          
            });
        }
    }
}
