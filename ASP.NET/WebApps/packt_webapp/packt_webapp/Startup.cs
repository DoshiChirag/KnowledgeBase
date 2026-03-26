using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace packt_webapp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.CreateLogger("packt_webapp");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (Context) =>
            {
                await Context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
