using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;

namespace SimpleInjectorDemo
{
    public class Startup
    {
        private Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Resolve types without needing explicit registration
            _container.Options.ResolveUnregisteredConcreteTypes = true;

            services.AddControllers();

            services.AddSimpleInjector(_container, options =>
            {
                // Register Controllers with simpleinjector
                // Tell .NETCore to use simpleinjector to contruct ASP controllers
                options
                    .AddAspNetCore()
                    .AddControllerActivation(); 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Finalize simpleinjector usage
            app.UseSimpleInjector(_container);

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
