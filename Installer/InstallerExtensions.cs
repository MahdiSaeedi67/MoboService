using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Installer
{
	public static class InstallerExtensions
	{
		public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
		{
			var Installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
				typeof(IInstaller).
				IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
				Select(Activator.CreateInstance).
				Cast<IInstaller>().OrderBy(o => o.Priority).ToList();

			Installers.ForEach(Installer =>
			{
				Installer.InstallServices(services, configuration);
			});
		}

	}

}
