using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Services;

namespace WebAPICore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LogErrores oLog = new LogErrores(@"C:\Users\migue\source\repos\WebAPICore\WebAPICore");
            oLog.Add("Soy un Error...Chale");
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
