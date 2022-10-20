
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Reflection;

namespace CurrencyRates
{
    public abstract class WebStartupBase
    {
        public abstract string WebApplicationName { get; }

        public WebStartupBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddOptions();
            AuthorizationConfigure(services);
            var serviceProvider = services.BuildServiceProvider();

            AfterConfigureService(services);
            services.AddRazorPages();
        }


        protected abstract void AfterConfigureService(IServiceCollection services);

        protected virtual void AuthorizationConfigure(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            BeforeConfigure(app);


            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("solomon-app-version", "0.0.1"/*VersionHelper.SystemVersion.ToString()*/);

                context.Request.EnableBuffering();
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        protected virtual void BeforeConfigure(IApplicationBuilder app)
        {
            app.UseRouting();
        }
    }
}
