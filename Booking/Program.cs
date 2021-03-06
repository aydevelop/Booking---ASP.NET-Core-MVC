using Booking.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Booking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            IServiceProvider serviceProvider = scope.ServiceProvider;

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddFile(Path.Combine($"{Directory.GetCurrentDirectory()}", "Log\\Log.txt"));

            try
            {
                DbInitializer.InitializeAsync(serviceProvider).Wait();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "DbInitializer Error");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
