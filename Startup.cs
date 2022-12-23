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
            // получаем строку подключения из файла конфигурации
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст ApplicationDBContext в качестве сервиса в приложение
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
            //контейнер с последовательным запуском пргомежуточных компонентов ...

            if (env.IsDevelopment())     // проверяем режим запуска приложения 
            {
                app.UseDeveloperExceptionPage();  // развернутый компонент анализа исключения 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");   // страница для пользователя с ошибкой 
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();                // переход на защищенное соединение 

            app.UseStaticFiles();                   // получаем доступ к статическим файлам 

            app.UseRouting();                     //  вкл и настройка маршрутизация (MVC,RAZOR... выбирает шаблон 

            app.UseAuthorization();              // включаем авторизацию 

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(        // включаем  точки входа MVC 
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                          // HOME- указывает на контроллер INDEX- на метод конторллера (если нету спользует метод по умолчанию)
            });
        }
    }
}
