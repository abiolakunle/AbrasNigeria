using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Extensions
{
    public static class SwaggerExtenstions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info
            {
                Version = "v1",
                Title = "Abras Nigeria Enterprises API",
                Description = "API for abrasnigeria.com",
                TermsOfService = new Uri("http://www.abrasnigeria.com").ToString(),
                Contact = new Contact()
                {
                    Name = "AbiolaSoft",
                    Email = "abiolasotf4u@gmail.com",
                    Url = "http://github.com/abiolakunle"
                }
            }

           ));
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
