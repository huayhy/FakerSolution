using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.Castle.Logging.Log4Net;
using Abp.Extensions;
using Faker.Solution.Configuration;
using Faker.Solution.Identity;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Dependency;
using Abp.Json;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Faker.Solution.GroupSwagger;
using System.IO;
using Abp.PlugIns;

namespace Faker.Solution.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";
        private const string _anyCorsPolicyName = "any";

        private const string _apiVersion = "v1";

        private readonly IConfigurationRoot _appConfiguration;

        /// <summary>
        /// 当前装配件的所在路径
        /// </summary>
        private string GetCurrentPath
        {
            get
            {
                var currentExecutingPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                return currentExecutingPath;
            }
        }

        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //MVC
            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
                }
            ).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddSignalR();

            // Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            // 允许所有跨域
            services.AddCors(options =>
            {
                options.AddPolicy(_anyCorsPolicyName, builder =>
                {
                    //所有都可以该用，相当于禁止了CORS
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });


            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            // 添加Swagger分组服务配置
            services.AddGroupSwagger(this._appConfiguration);
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc(_apiVersion, new OpenApiInfo
            //    {
            //        Version = _apiVersion,
            //        Title = "Solution API",
            //        Description = "Solution",
            //        // uncomment if needed TermsOfService = new Uri("https://example.com/terms"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Solution",
            //            Email = string.Empty,
            //            Url = new Uri("https://twitter.com/aspboilerplate"),
            //        },
            //        License = new OpenApiLicense
            //        {
            //            Name = "MIT License",
            //            Url = new Uri("https://github.com/aspnetboilerplate/aspnetboilerplate/blob/dev/LICENSE"),
            //        }
            //    });
            //    options.DocInclusionPredicate((docName, description) => true);

            //    // Define the BearerAuth scheme that's in use
            //    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
            //    {
            //        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey
            //    });
            //});

            // Configure Abp and Dependency Injection
            //return services.AddAbp<SolutionWebHostModule>(
            //    // Configure Log4Net logging
            //    options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
            //        f => f.UseAbpLog4Net().WithConfig("log4net.config")
            //    )
            //);
            return services.AddAbp<SolutionWebHostModule>(
                // Configure Log4Net logging
                options => {
                    options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                         f => f.UseAbpLog4Net().WithConfig("log4net.config")

                         
                     );

                    // 如果存在插件目录则加入运行时环境
                    var pluginPath = Path.Combine(GetCurrentPath, "Plugins");
                    if (Directory.Exists(pluginPath))
                    {
                        options.PlugInSources.AddFolder(pluginPath, SearchOption.AllDirectories);
                    }
                }
            );
        }

        public void Configure(IApplicationBuilder app,  ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.

            //app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAbpRequestLocalization();

            app.UseCors(_appConfiguration["App:CorsOrigins"].Contains("*:*") ? _anyCorsPolicyName : _defaultCorsPolicyName); // Enable CORS!

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AbpCommonHub>("/signalr");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            //app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            //app.UseSwaggerUI(options =>
            //{
            //    // specifying the Swagger JSON endpoint.
            //    options.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", $"Solution API {_apiVersion}");
            //    options.IndexStream = () => Assembly.GetExecutingAssembly()
            //        .GetManifestResourceStream("Faker.Solution.Web.Host.wwwroot.swagger.ui.index.html");
            //    options.DisplayRequestDuration(); // Controls the display of the request duration (in milliseconds) for "Try it out" requests.  
            //}); // URL: /swagger

            app.UseGroupSwagger(this._appConfiguration, loggerFactory);
        }
    }
}
