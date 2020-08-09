using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
	public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly Stopwatch _timer;
		private readonly ILogger<TRequest> _logger;

		public PerformanceBehaviour(
			ILogger<TRequest> logger)
		{
			_timer = new Stopwatch();
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			_timer.Start();

			TResponse response = await next();

			_timer.Stop();

			long elapsedMilliseconds = _timer.ElapsedMilliseconds;

			if (elapsedMilliseconds > 500)
			{
				string requestName = typeof(TRequest).Name;
				string userName = string.Empty;

				_logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserName} {@Request}", requestName, elapsedMilliseconds, userName, request);
			}

			return response;
		}
	}
}