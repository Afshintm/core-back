using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
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
            //Overiding Kerstrel config in appsetting.{environment}.json with 
            // .ConfigureServices((context, services) =>
            // {
            //     services.Configure<KestrelServerOptions>(
            //         context.Configuration.GetSection("Kestrel"));
            // })
            .UseSerilog(); // using Serilog


            //setup Kestrel and other WebHostBuilder which can be customized with following action
            hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                //.UseUrls("http://localhost:5060;https://localhost:5061")
                .UseStartup<Startup>();
            });
            return hostBuilder;
        }

    }
}
