using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Installer
{
    public interface IInstaller
    {
        int Priority { get; }
        void InstallServices(IServiceCollection services, IConfiguration Configuration);
    }
}
