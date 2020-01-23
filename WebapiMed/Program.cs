using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace WebapiMed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arguments = Environment.GetCommandLineArgs();
            var e = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File(new RenderedCompactJsonFormatter(), "log.ndjson")
            .WriteTo.File("log.txt")
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
            if (args != null)
            {
                var i = 0;
                foreach (var item in args)
                {
                    Log.Information($"args index {i} = {item}");
                }
            }
            var e = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Log.Information($"Building host with args: {string.Join(",", args)} ,Environment: {e}");

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
