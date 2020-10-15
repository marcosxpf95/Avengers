using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWash.Infra.Contexts;
using MyWash.Infra.Repositories;
using MyWash.Model.Repositories;

namespace MyWash.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddDbContext<MyWashContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("CommanderConnection"),
                       optionsBuilder =>
                           optionsBuilder.MigrationsAssembly("MyWash.Api")
                   )
              );

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
        }
       
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
