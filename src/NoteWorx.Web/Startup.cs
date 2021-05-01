using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoteWorx.Web.Infrastructure.DependencyInjection;

namespace NoteWorx.Web
{
    public sealed class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(
           IConfiguration configuration,
           IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration
               ?? throw new ArgumentNullException(nameof(configuration));

            _hostingEnvironment = hostingEnvironment
               ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureAppServices(_configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            if (_hostingEnvironment.IsDevelopment())
                app.UseNodeModules();

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
