using Application.Forecasts.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazinForecasts.API
{
	public class ForecastApi
	{
		private readonly IMediator _mediator;

		public ForecastApi(IMediator mediator) => _mediator = mediator;

		[FunctionName("forecast")]
		public async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
			ILogger log)
		{
			var postcode = req.Query["postcode"].ToString();

			IEnumerable<WeatherForecastDto> result = await _mediator.Send(new GetForecast()
			{
				Postcode = postcode
			});

			return new JsonResult(result);
		}
	}
}
