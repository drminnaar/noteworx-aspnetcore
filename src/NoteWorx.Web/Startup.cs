using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteWorx.Infrastructure.Data;
using NoteWorx.Infrastructure.Data.Commands;
using NoteWorx.Infrastructure.Data.Models;
using NoteWorx.Infrastructure.Data.Queries;
using NoteWorx.Infrastructure.Data.Repositories;
using NoteWorx.Web.Infrastructure.DependencyInjection;

namespace NoteWorx.Web
{
   public sealed class Startup
   {
      private readonly IConfiguration _configuration;
      private readonly IHostingEnvironment _hostingEnvironment;

      public Startup(
         IConfiguration configuration,
         IHostingEnvironment hostingEnvironment)
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
            app.UseNodeModules(_hostingEnvironment);

         app.UseStatusCodePagesWithReExecute("/error/{0}");
         app.UseAuthentication();
         app.UseMvcWithDefaultRoute();
      }
   }
}
