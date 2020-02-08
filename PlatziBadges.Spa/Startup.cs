using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlatziBadges.Data;
using PlatziBadges.Service;

namespace PlatziBadges.Spa
{
    /// <summary>
    /// _ _ _ _ _ _ _ _ _ _ _ 
    /// # Migración Inicial #
    /// ---------------------
    /// 
    /// Add-Migration InitialCreate
    /// 
    /// _ _ _ _ _ _ _ _ _ _ _ _ _ 
    /// # Crear la base de datos #
    /// --------------------------
    /// 
    /// Update-Database
    /// 
    /// </summary>
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
            //services.AddControllersWithViews();

            services.AddDbContext<PlatziBadgesContext>(
                options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"))
            );

            services.AddScoped<IBadgeService, BadgeService>();

            #region CORS
            //Configuración de Politica [personalizada]
            services.AddCors(options => options.AddPolicy("CORSReactPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Configuración de Politica [permitir todo]
            //services.AddCors();
            #endregion



            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            #region CORS
            //Configuración de Politica [personalizada]
            app.UseCors("CORSReactPolicy");

            //Configuración de Politica [permitir todo]
            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            #endregion


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
                }
            });
        }
    }
}
