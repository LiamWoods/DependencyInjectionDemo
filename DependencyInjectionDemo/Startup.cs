using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DependencyInjectionDemo.InheritanceOverFactory;
using DependencyInjectionDemo.Utils.FactoryItems;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionDemo
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
            services.AddControllers();

            services.AddSingleton<ICakeFactory, FreshCakeFactory>();
            services.AddSingleton<CakeFactoryFactory>();
            services.AddSingleton<ExternalCakeFactory>();

            services.AddHttpClient("", client =>
            {
                client.BaseAddress = new Uri("http://cakes.com/api/stale/");
            });
            services.AddHttpClient("fresh", client =>
            {
                client.BaseAddress = new Uri("http://cakes.com/api/fresh/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "TOKEN");
            });

            services.Configure<OldConfig>(options => Configuration.GetSection("ExternalConnections:OldConfiguration").Bind(options));
            services.Configure<NewConfig>(options => Configuration.GetSection("ExternalConnections:NewConfiguration").Bind(options));

            services.AddSingleton<IRepo<OldConfig>, OldRepo>();
            services.AddSingleton<IRepo<NewConfig>, NewRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
