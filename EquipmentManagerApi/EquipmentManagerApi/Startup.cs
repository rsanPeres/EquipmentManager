using AutoMapper;
using EquipmentManager.Application.Interfaces;
using EquipmentManager.Application.Services;
using EquipmentManager.Application.Settings;
using EquipmentManager.Domain.Interfaces.Repository;
using EquipmentManager.Infrastructure;
using EquipmentManager.Repository;
using EquipmentManager.Repository.Repositories;
using EquipmentManagerApi.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BreakevenStoneApi
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
            services.AddControllers();

            AddApplicationAuthentication(services);

            services.AddDbContext<ApplicationContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("EquipmentManager")));

            AddApplicationMappers(services);
            AddApplicationServices(services);
            AddApplicationRepositories(services);
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void AddApplicationRepositories(IServiceCollection services)
        {
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentModelRepository, EquipmentModelRepository>();
            services.AddScoped<IEquipmentModelStateHourlyEarningRepository, EquipmentModelStateHourlyEarningRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEquipmentStateRepository, EquipmentStateRepository>();
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<IEquipmentModelService, EquipmentModelService>();
            services.AddScoped<IEquipmentModelStateHourlyEarningService, EquipmentModelStateHourlyEarningService>();
            services.AddScoped<IEquipmentStateService, EquipmentStateService>();

        }

        private static void AddApplicationMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMappers());
                mc.AddProfile(new EquipmentMappers());
                mc.AddProfile(new EquipmentModelMappers());
                mc.AddProfile(new EquipmentModelStateHourlyEarningMappers());
                mc.AddProfile(new EquipmentStateMappers());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddApplicationAuthentication(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(TokenSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }
    }
}