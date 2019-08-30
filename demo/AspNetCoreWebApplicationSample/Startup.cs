using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ezreal.EasyPay.WeChat;
using Ezreal.EasyPay.WeChat.ApiContract;
using Ezreal.EasyPay.WeChat.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebApiClient.Extensions.DependencyInjection;

namespace AspNetCoreWebApplicationSample
{
    public class Startup
    {

        public virtual string FriendlyName { get; protected set; } = AppDomain.CurrentDomain.FriendlyName;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(FriendlyName, new Info
                {
                    Version = "v1",
                    Title = $"{FriendlyName} API",
                    Description = $"{FriendlyName} API SwaggerUI",
                    Contact = new Contact
                    {
                        Name = $"{FriendlyName} API",
                        Email = string.Empty,
                    }
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                string basePath = Path.GetDirectoryName(this.GetType().Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                string xmlPath = Path.Combine(basePath, $"{FriendlyName}.xml");
                option.IncludeXmlComments(xmlPath);

            });

            if (true)//无DI或引入DI但无多商户要求
            {
                WeChatPayOptions.DefaultInstance = new WeChatPayOptions()
                {
                    //配置默认配置
                };
                //此过程可以不在此处进行
                //WeChatPayCredentialsCache.DefaultInstance.AddOrUpdateCredentials("商户号", new X509Certificate2(@"你的p12证书", "商户号", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable));
                WeChatPayConfigurationManager.DefaultInstance.Configure("商户号");
            }


            services.AddSingleton<WeChatPayCredentialsCache>(WeChatPayCredentialsCache.DefaultInstance);
            //若将WeChatPayConfigurationManager引入DI  则必须将WeChatPayCredentialsCache引入DI 
            services.AddSingleton<WeChatPayConfigurationManager>(WeChatPayConfigurationManager.DefaultInstance);

            services.AddTransient<Ezreal.EasyPay.WeChat.Api.WeChatPayClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint($"/swagger/{FriendlyName}/swagger.json", $"{FriendlyName}");
            });

        }
    }
}
