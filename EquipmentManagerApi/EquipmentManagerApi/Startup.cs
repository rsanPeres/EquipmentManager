using EquipmentManager.Application.Services;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using EquipmentManager.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BreakevenStoneApi
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
            services.AddDbContext<ApplicationContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("EquipmentManager")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<EquipmentService, EquipmentService>();
            services.AddScoped<EquipmentRepository, EquipmentRepository>();
            AddApplicationServices(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EquipmentManagerApi", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "EquipmentManagerApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        }

    }
}