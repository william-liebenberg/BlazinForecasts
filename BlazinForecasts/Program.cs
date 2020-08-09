using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazinForecasts.UI
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:4034/api") });
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7071") });

			// func host start --cors *
			await builder.Build().RunAsync();
		}
	}
}
