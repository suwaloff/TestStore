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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // �������� ������ ����������� �� ����� ������������
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            // ��������� �������� ApplicationDBContext � �������� ������� � ����������
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));     
            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //��������� � ���������������� �������� �������������� ����������� ...

            if (env.IsDevelopment())     // ��������� ����� ������� ���������� 
            {
                app.UseDeveloperExceptionPage();  // ����������� ��������� ������� ���������� 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");   // �������� ��� ������������ � ������� 
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();                // ������� �� ���������� ���������� 

            app.UseStaticFiles();                   // �������� ������ � ����������� ������ 

            app.UseRouting();                     //  ��� � ��������� ������������� (MVC,RAZOR... �������� ������ 

            app.UseAuthorization();              // �������� ����������� 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(        // ��������  ����� ����� MVC 
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                          // HOME- ��������� �� ���������� INDEX- �� ����� ����������� (���� ���� ��������� ����� �� ���������)
            });
        }
    }
}