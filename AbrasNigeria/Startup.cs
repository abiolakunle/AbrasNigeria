using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Extensions;
using AbrasNigeria.Data.Helpers;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Repositories;
using AbrasNigeria.Data.Services;
using AbrasNigeria.Data.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AbrasNigeria
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IHostingEnvironment HostingEnvironment { get; }
        public Startup(IConfiguration config, IHostingEnvironment hostingEnv)
        {
            Configuration = config;
            HostingEnvironment = hostingEnv;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddScoped(sp => new SessionCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            services.AddSwagger();

            //configure stringly typed settings object
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddCustomAuthentication(appSettings.Secret);

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), HostingEnvironment.WebRootPath)));

            if (HostingEnvironment.IsDevelopment())
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration["ConnectionStrings:TestConnection"]
                ));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration["ConnectionStrings:RemoteConnection"]
                ));
            }

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ExcelPartBookToDb>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IDescriptionRepository, DescriptionRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IMachineRepository, MachineRepository>();
            services.AddTransient<ISectionGroupRepository, SectionGroupRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IStockProductRepository, StockProductRepository>();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IUserService userService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(x =>
                x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseCustomSwagger();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
            if (HostingEnvironment.IsProduction())
            {
                DbInitializer.DoMigration(app);
            }
            AdminCreator.CreateSuperAdmin(app.ApplicationServices);

        }
    }
}
