using System;
using System.Collections.Generic;
using System.Text;
using Application;
using Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

[assembly: FunctionsStartup(typeof(BlazinForecasts.API.Startup))]
namespace BlazinForecasts.API
{
	internal class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			ServiceProvider sp = builder.Services.BuildServiceProvider();
			IConfiguration config = sp.GetRequiredService<IConfiguration>();

			builder.Services.AddLogging(o =>
				o.AddSerilog(new LoggerConfiguration()
					// TODO: Add Seq
					.WriteTo.Console(outputTemplate: "[{Timestamp:d/MM/yyyy hh:mm:ss tt}] {Message:lj}{NewLine}{Exception}")
					.CreateLogger()));

			builder.Services.AddApplication(config);
			builder.Services.AddInfrastructure(config);
		}
	}
}
