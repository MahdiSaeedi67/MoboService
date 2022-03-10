using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using AppointmentService.Filters;
using AppointmentService.Options;
namespace AppointmentService.Installer
{
    

    public class MvcInstaller : IInstaller
    {
        public int Priority => 4;
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());


            services.AddAutoMapper(typeof(Startup));
        }
    }
}
