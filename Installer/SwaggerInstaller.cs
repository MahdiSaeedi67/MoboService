using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace AppointmentService.Installer
{
    public class SwaggerInstaller : IInstaller
    {
        public int Priority => 2;
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Cash", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                { 
                    {"Bearer",new string[0] }
                };


                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization Header Using The Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    { new OpenApiSecurityScheme{ Reference=new OpenApiReference
                    {
                        Id="Bearer",
                        Type=ReferenceType.SecurityScheme
                    } },new List<string>()}
                });
            });
        }
    }
}
