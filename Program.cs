using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AppointmentService;

namespace AppointmentService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			System.Globalization.CultureInfo.CurrentCulture =
				new CultureInfo("fa-IR");

			System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat = new CultureInfo("fa-IR").DateTimeFormat;
			//Console.WriteLine(System.DateTime.Now);
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
