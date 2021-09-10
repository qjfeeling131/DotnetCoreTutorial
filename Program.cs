using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StructureMap.AspNetCore;
using Microsoft.AspNetCore;
using DotnetCoreTutorial.Infrastructure;

namespace DotnetCoreTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Host
            //CreateHostBuilder(args).Build().Run();

            //Web Host
            var webHost = CreateWebHostBuilder(args).Build();
            //webHost.MigrateDbContext<EFDbContext>((_, _) => { });

            webHost.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStructureMap();
        //            webBuilder.UseStartup<Startup>();

        //        });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder()
            .UseStructureMap()
            .UseStartup<Startup>();
    }
}
