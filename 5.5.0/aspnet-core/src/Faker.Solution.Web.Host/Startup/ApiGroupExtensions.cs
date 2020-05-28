/*
    配置API分组数据
 */
using Abp.Extensions;
using Faker.Solution.Web.Host.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Faker.Solution.GroupSwagger
{
    public static class ApiGroupExtensions
    {
        public const string Default = "default";

        /// <summary>
        /// 分组清单
        /// </summary>
        public static List<APIGroupInfo> ApiGroups;

        public static string LoadDescription(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// 配置默认分组数据
        /// </summary>
        public static void InitConfigure() {

            // 读取文档说明html文件
            var currentExecutingPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
            //string template = "Hello @Model.Name, welcome to RazorEngine!";
            //string result = RazorHelper.ToRazorText(template, new { Name = "World" });
            //var htmlFileName = string.Format(currentExecutingPath)
            string result = ApiGroupExtensions.LoadDescription(string.Format("{0}//Solution.html", currentExecutingPath));
            ApiGroupExtensions.ApiGroups = new List<APIGroupInfo>();

            // 添加默认分组（默认数据请勿改动）
            ApiGroups.Add(new APIGroupInfo
            {
                Name = "default",
                OpenApiInfo = new OpenApiInfo
                {
                    Title = "默认模块",
                    Version = "default",
                    Description =  result, //"这里是ABP默认的文档清单<br/> 项目开始时间：2020-05-14",
                    //Contact = new OpenApiContact
                    //{
                    //     Name = "华威",
                    //    Email = "huayhy@126.com",
                    //      Url = new Uri("http://www.baidu.com"),
                    //},
                    //License = new OpenApiLicense { 
                    //  Name = "数据授权许可证",
                    //   Url = new Uri("http://www.baidu.com")
                    //},
                    //TermsOfService = new Uri("http://www.baidu.com")
                }
            });
            // 添加默认分组（默认数据请勿改动）
            ApiGroups.Add(new APIGroupInfo
            {
                Name = "Manager",
                OpenApiInfo = new OpenApiInfo
                {
                    Title = "管理端模块",
                    Version = "Manager"
                }
            });

            // 添加默认分组（默认数据请勿改动）
            ApiGroups.Add(new APIGroupInfo
            {
                Name = "Client",
                OpenApiInfo = new OpenApiInfo
                {
                    Title = "客户端模块",
                    Version = "Client"
                }
            });
            // 添加默认分组（默认数据请勿改动）
            ApiGroups.Add(new APIGroupInfo
            {
                Name = "Extend",
                OpenApiInfo = new OpenApiInfo
                {
                    Title = "扩展服务",
                    Version = "Extend"
                }
            });

            // 添加默认分组（默认数据请勿改动）
            ApiGroups.Add(new APIGroupInfo
            {
                Name = "Plugins",
                OpenApiInfo = new OpenApiInfo
                {
                    Title = "插件模块",
                    Version = "Plugins"
                }
            });
        }

        /// <summary>
        /// 在StartUp中的中的，ConfigureServices中调用这个配置方法用于处理Swagger文档的分组
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddGroupSwagger(this IServiceCollection services, IConfigurationRoot configuration)
        {
            // 初始化分组数据
            ApiGroupExtensions.InitConfigure();
            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                // 添加所有分组
                foreach (var model in ApiGroupExtensions.ApiGroups)
                {
                    options.SwaggerDoc(model.Name, model.OpenApiInfo);
                }
                // 归类API文档 
                options.DocInclusionPredicate((docName, description) => {

                    // 描述分组名称为空则属于默认模块
                    if (docName == ApiGroupExtensions.Default)
                    {
                        // 分组名称为空归属于默认 | 分组名称没有定义到常量中归属于默认
                        if (string.IsNullOrEmpty(description.GroupName))
                            return true;
                        if (!ApiGroupExtensions.ApiGroups.Any(x => x.Name == description.GroupName))
                        {
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return description.GroupName == docName;   // 根据组名称来划分
                    }
                });


                var currentExecutingPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlNameConfig = configuration["Swagger:XmlDocName"];

                //此配置可直接映射application层也可以映射host中控制器那层
                //所有可能出现多个xml name
                //存在多个配置
                if (xmlNameConfig != null) {
                    if (xmlNameConfig.Contains(';'))
                    {
                        foreach (var item in xmlNameConfig.Split(';'))
                        {
                            // 查找编译路径下的服务文档
                            if (File.Exists($"{currentExecutingPath}\\{item}.xml"))
                            {
                                options.IncludeXmlComments($"{currentExecutingPath}\\{item}.xml", true);
                            }
                            // 查找插件路径下的服务文档
                            //if (File.Exists($"{currentExecutingPath}\\plugins\\{item}\\{item}.xml"))
                            //{
                            //    options.IncludeXmlComments($"{currentExecutingPath}\\plugins\\{item}\\{item}.xml", true);
                            //}
                        }
                    }
                }
                

                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });
            return services;
        }
        /// <summary>
        /// 在StartUp中的中的，Configure中调用这个配置方法用于处理Swagger文档的分组
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <param name="loggerFactory"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGroupSwagger(this IApplicationBuilder app, IConfigurationRoot configuration, ILoggerFactory loggerFactory)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            // 新的分组文档处理
            app.UseSwaggerUI(options =>
            {

                foreach (var model in ApiGroupExtensions.ApiGroups)
                {
                    options.SwaggerEndpoint(string.Format("{0}swagger/{1}/swagger.json", configuration["App:ServerRootAddress"].EnsureEndsWith('/'), model.Name), model.OpenApiInfo.Title);
                }
            
                options.IndexStream = () => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("Faker.Solution.Web.Host.wwwroot.swagger.ui.index.html");
            }); // URL: /swagger

            return app;
        }
    }

    /// <summary>
    /// API分组信息
    /// </summary>
    public class APIGroupInfo
    { 
        /// <summary>
        /// 接口名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 接口信息
        /// </summary>
        public OpenApiInfo OpenApiInfo { get; set; }
    }
}
