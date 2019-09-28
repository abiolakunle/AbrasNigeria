using AbrasNigeria.Data.DbContexts;
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

            services.AddScoped<SessionCart>(sp => new SessionCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper();

            //configure stringly typed settings object
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(
                x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userServices = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            var userId = int.Parse(context.Principal.Identity.Name);
                            var user = userServices.GetById(userId);
                            if (user == null)
                            {
                                //return unauthorized if user no longer exists
                                context.Fail("Unauthorized");
                            }

                            return Task.CompletedTask;
                        }

                    };

                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

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
            services.AddTransient<ICategoryRepository, CategoryRepository>();
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
        }
    }
}
