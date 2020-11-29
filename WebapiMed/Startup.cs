using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebapiMed.Infrastructure;
using WebapiMed.Models;

namespace WebapiMed
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            //services.Configure<SerilogSettings>(Configuration.GetSection("SerilogSettings"));

            services.AddOptions<SerilogSettings>()
                .Bind(Configuration.GetSection(nameof(SerilogSettings)))
                .ValidateDataAnnotations()
                .Validate(
                    config =>
                    {
                        if (string.IsNullOrEmpty(config.LoggingEndpoint))
                        {
                            return false;
                        }

                        return true;
                    }, "ClientId is null");

            var goodmentsConfig = new GoodmentsConfig();
            Configuration.Bind("GoodmentsConfig", goodmentsConfig);
            services.AddSingleton(goodmentsConfig);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddControllers();
            services.AddControllersWithViews(opts =>
            {
                opts.Filters.Add<SerilogMvcLoggingAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
