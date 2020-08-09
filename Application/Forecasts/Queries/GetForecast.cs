using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Forecasts.Queries
{
	public sealed class GetForecast : IRequest<IEnumerable<WeatherForecastDto>>
	{
		public string Postcode { get; set; }

		private class Handler : IRequestHandler<GetForecast, IEnumerable<WeatherForecastDto>>
		{
			private readonly IWeatherService _weatherService;
			private readonly IMapper _mapper;

			public Handler(IWeatherService weatherService, IMapper mapper)
			{
				_weatherService = weatherService;
				_mapper = mapper;
			}

			public async Task<IEnumerable<WeatherForecastDto>> Handle(GetForecast request, CancellationToken cancellationToken)
			{
				IEnumerable<Forecast> forecast = await _weatherService.Forecast(request.Postcode);

				// map Forecast (Domain) to WeatherForecastDto
				return forecast.Select(f => _mapper.Map<WeatherForecastDto>(f));
			}
		}
	}
}