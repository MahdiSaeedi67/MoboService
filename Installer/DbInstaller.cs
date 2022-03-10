using AppointmentService.Data;
using AppointmentService.Services.v1.Implementation;
using AppointmentService.Services.v1.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using AppointmentService.Options;


namespace AppointmentService.Installer
{
    public class DbInstaller : IInstaller
    {
        public int Priority => 3;
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<DBAppointmentContext>(Options =>
            Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnction")), ServiceLifetime.Singleton);

            services.AddScoped<IExpertService, ExpertService>();
            services.AddScoped<IExpertiseService, ExpertiseService>();
            services.AddScoped<IAdvertiesService, AdvertiesService>();
            services.AddScoped<IAppointmentService, AppointmentService.Services.v1.Implementation.AppointmentService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<ISearchCityService, SearchCityService>();
            services.AddScoped<IInformationBaseService, InformationBaseService>();
            services.AddScoped<IUserManagmentService, UserManagmentService>();

            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();

            var sp = services.BuildServiceProvider();
            var dbcontext = sp.GetRequiredService<DBAppointmentContext>();
            AuthenticationManagerService authenticationManagerService = new AuthenticationManagerService(dbcontext, (Configuration.GetSection("JwtSettings").GetValue<string>("Secret")));
            services.AddSingleton(typeof(IAuthenticationManagerService), authenticationManagerService);

        }
    }
}
