using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace WebapiMed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application starup failed .");
            }
            finally
            {
                Log.CloseAndFlush();

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            var j = string.Join(",", args);
            var str = new StringBuilder();
            Array.ForEach(args, i => str.Append(i));
            Log.Information($"Building host with args {str.ToString()}");

            var hostBuilder = Host
            .CreateDefaultBuilder(args)
            .UseSerilog(); // using Serilog

            hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
            return hostBuilder;
        }

    }
}
