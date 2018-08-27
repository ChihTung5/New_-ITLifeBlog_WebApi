using DAL.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;


namespace UI.Api
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
            services.AddDbContext<ITLifeBlogDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ITLifeBlog")));

            #region 跨域设置
            services.AddCors(options =>
            {
                options.AddPolicy("AppDomain", builder =>
                {
                    builder.AllowAnyOrigin()    // Allow access to any source from the host
                    .AllowAnyMethod()           // Ensures that the policy allows any method
                    .AllowAnyHeader()           // Ensures that the policy allows any header
                    .AllowCredentials();        // Specify the processing of cookie
                });
            });
            #endregion

            #region 配置Swagger测试文档
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ITLifeBlog接口文档",
                    Description = "RESTful API for ITLifeBlog.",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "gwidon", Email = "gwidon.wu@bedrock.com.cn", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "UI.Api.xml");
                options.IncludeXmlComments(xmlPath);
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AppDomain");//实现全局跨域设置

            app.UseHttpsRedirection();

            #region 配置swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.ShowExtensions();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ITLifeBlog v1");
            });
            #endregion

            #region 自定义路由配置
            //app.UseMvc(routes =>
            //{
            //    //自定义路由
            //    routes.MapRoute(
            //        name: "default",
            //        template: "api/{controller}/{action}/{id?}",
            //        defaults: new { controller = "Values", action = "Index" });

            //    //默认路由
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Values", action = "Index" });
            //});
            #endregion

            #region NLog配置
            loggerFactory.AddNLog();    //添加NLog
            loggerFactory.ConfigureNLog($"{Directory.GetCurrentDirectory()}\\Nlog.config");//添加Nlog.config配置文件
            loggerFactory.AddDebug();
            #endregion

            app.UseMvc();
        }
    }
}
