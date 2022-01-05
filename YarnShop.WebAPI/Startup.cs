using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.Repositories;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zawodnicy.WebAPI", Version = "v1" });
            });

            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
                .AddCertificate(options =>
                {
                    options.Events = new CertificateAuthenticationEvents
                    {
                        OnCertificateValidated = context =>
                        {
                            var claims = new[]
                            {
                                new Claim(
                                    ClaimTypes.NameIdentifier,
                                    context.ClientCertificate.Subject,
                                    ClaimValueTypes.String,
                                    context.Options.ClaimsIssuer),
                                new Claim(ClaimTypes.Name,
                                    context.ClientCertificate.Subject,
                                    ClaimValueTypes.String,
                                    context.Options.ClaimsIssuer)
                            };

                            context.Principal = new ClaimsPrincipal(
                                new ClaimsIdentity(claims, context.Scheme.Name));
                            context.Success();

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<IColorsRepository, ColorsRepository>();
            services.AddScoped<IColorsService, ColorsService>();

            services.AddScoped<IKnittingNeedlesRepository, KnittingNeedlesRepository>();
            services.AddScoped<IKnittingNeedlesService, KnittingNeedlesService>();

            services.AddScoped<IKitsRepository, KitsRepository>();
            services.AddScoped<IKitsService, KitsService>();

            services.AddScoped<IYarnBundlesRepository, YarnBundlesRepository>();
            services.AddScoped<IYarnBundlesService, YarnBundlesService>();

            services.AddScoped<IYarnTypesRepository, YarnTypesRepository>();
            services.AddScoped<IYarnTypesService, YarnTypesService>();

            services.AddDbContext<AppDbContext>(
                 options => options.UseSqlServer(
                     Configuration.GetConnectionString("YarnShopConnectionString")
                 )
             );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zawodnicy.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
