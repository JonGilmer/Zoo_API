using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // calls the CreateHostBuilder method to build the host
            CreateHostBuilder(args).Build().Run();
        }

        // Uses CreateHostBuilder method to build a default host using the startup configuration settings
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
