using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Laba_1.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace laba_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(log =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "fileInfoLog.txt");
                log.ClearProviders();
                log.AddProvider(new FileLoggerProvider(path));
                log.AddFilter("Microsoft", LogLevel.None);
            })
                .UseStartup<Startup>();
    }
   
}
