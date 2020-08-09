using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
	public class WeatherService : IWeatherService
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly Random _rng = new Random();

		public async Task<IEnumerable<Forecast>> Forecast(string postcode)
		{
			return await Task.FromResult(Enumerable.Range(1, 5).Select(index =>
			{
				var forecast = new Forecast
				{
					Date = DateTime.Now.AddDays(index),
					Temperature = _rng.Next(-20, 55),
					Summary = Summaries[_rng.Next(Summaries.Length)]
				};
				return forecast;
			}).ToArray());
		}
	}
}