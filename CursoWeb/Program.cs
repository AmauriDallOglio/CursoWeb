using CursoWeb.Services;
using Refit;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;

namespace CursoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(builder.Environment.ContentRootPath)
          .AddJsonFile("appsettings.Development.json")
          .Build();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            builder.Services.AddRefitClient<IUsuarioService>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("UrlApiCurso"));
                }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);
            
            builder.Services.AddRefitClient<ICursoService>()
                  .ConfigureHttpClient(c =>
                  {
                      c.BaseAddress = new Uri(configuration.GetValue<string>("UrlApiCurso"));
                  }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);



            //builder.Services.AddTransient<BearerTokenHandler>();

            //builder.Services.AddRefitClient<ICourseServices>()
            //    .AddHttpMessageHandler<BearerTokenHandler>()
            //   .ConfigureHttpClient(c =>
            //   {
            //       c.BaseAddress = new Uri(Configuration.GetValue<string>("UrlApiCurso"));
            //   }).ConfigurePrimaryHttpMessageHandler(c => clientHandler);





            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
