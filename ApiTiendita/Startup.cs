using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ApiTiendita.Controllers;
using ApiTiendita.Services;
using ApiTiendita.Middleware;

namespace ApiTiendita
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
            // Add services to the container.

            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
           
            services.AddTransient<IService, ServiceB>();
            //services.AddTransient<ServiceA>();
            services.AddTransient<ServiceTransient>();
            //services.AddTransient<IService, ServiceA>();
            services.AddScoped<ServiceScoped>();
            //services.AddTransient<IService, ServiceA>();
            services.AddSingleton<ServiceSingleton>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiTiendita", Version = "v1" });
            });
        }
        app.Map("maping", app =>
        {    app.Run(Async context =>{
                await context.Response.WriteAsync("Interceptando las peticiones");
            });
        });

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
     
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
