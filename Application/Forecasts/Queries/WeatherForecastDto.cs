using System;
using Application.Mappings;
using AutoMapper;
using Domain;

namespace Application.Forecasts.Queries
{
	public class WeatherForecastDto : IMapFrom<Forecast>
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public string Summary { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Forecast, WeatherForecastDto>()
			  .ForMember(d => d.TemperatureC, opt => opt.MapFrom(s => s.Temperature));
		}
	}
}