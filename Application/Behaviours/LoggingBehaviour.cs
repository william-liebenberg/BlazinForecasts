using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
	public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
	{
		private readonly ILogger _logger;

		public LoggingBehaviour(ILogger<TRequest> logger)
		{
			_logger = logger;
		}

		public Task Process(TRequest request, CancellationToken cancellationToken)
		{
			string requestName = typeof(TRequest).Name;
			var userName = string.Empty;

			_logger.LogInformation("Request: {Name} {@UserName} {@Request}", requestName, userName, request);

			return Task.CompletedTask;
		}
	}
}