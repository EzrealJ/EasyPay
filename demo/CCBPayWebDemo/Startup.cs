using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ezreal.EasyPay.MergeChannels.CCB;
using Ezreal.EasyPay.MergeChannels.CCB.HttpInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiClient.Extensions.DependencyInjection;

namespace CCBPayWebDemo
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
            services.AddControllersWithViews();
            services.AddScoped<CCBPayOptions>();//ע��ΪScope���ɺ�Http�������������Ӧ�Զ��̻��ĳ�����ÿ���̻��������������е�������
            services.AddHttpApi<ICCBPayContract>();
            services.AddHttpApi<ICCBEBS5Contract>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pay}/{action=PrePayView}/{id?}");
            });
        }
    }
}
