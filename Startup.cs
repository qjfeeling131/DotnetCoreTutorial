using DotnetCoreTutorial.Core.Midware;
using DotnetCoreTutorial.Infrastructure.Configuration.AutoMapper;
using DotnetCoreTutorial.Infrastructure.StructureMap;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StructureMap;
using System;
using System.Reflection;


namespace DotnetCoreTutorial
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
            //IIS windows identity
            //https://docs.microsoft.com/zh-cn/aspnet/core/security/authentication/windowsauth?view=aspnetcore-5.0&tabs=netcore-cli
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            //Kestrel windows identity
            //Negotiate �������������������Ƿ�֧�ֱ��� Windows �����֤�Լ��Ƿ������á�
            //���������֧�� Windows �����֤�������������������������Ҫ�������÷�����ʵ�֡� ����ڷ������������� Windows �����֤��
            //��Э�̴���������͸����ʽת�����������֤��
            //         services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //.AddNegotiate();
            services.AddCustomizedDbContext(Configuration);
            services.AddAutoMapper(typeof(ModelToDtoProfile), typeof(DtoToModelProfile));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetCoreTutorial", Version = "v1" });
            });
            services.AddControllers();
          

        }

        public void ConfigureContainer(Registry registry)
        {
            registry.IncludeRegistry<ServiceRegistry>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetCoreTutorial v1"));
            }

            //app.UseBasketMiddleware();
            //app.run(async context =>
            //{
            //    var identity = context.user.identity;
            //    await context.response.writeasync($"basket {identity.name}");
            //});
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseBasketMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }

    public static class CustomziedExtension
    {
        public static IServiceCollection AddCustomizedDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            //Default life time is scoped
            services.AddDbContext<EFDbContext>(options => options.UseMySql(connectionString,
                  new MariaDbServerVersion(new Version(10, 5, 0)),
                  mySqlOptionsAction: sqlOptions =>
                  {
                      sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                      sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                  }));
            return services;
        }
    }
}
