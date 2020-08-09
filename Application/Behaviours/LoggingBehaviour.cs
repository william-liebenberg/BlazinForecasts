using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
	public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
	{
		private readonly ILogger _logger;
		// private readonly ICurrentUserService _currentUserService;
		// private readonly IIdentityService _identityService;

		//public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
		public LoggingBehaviour(ILogger<TRequest> logger)
		{
			_logger = logger;
			// _currentUserService = currentUserService;
			// _identityService = identityService;
		}

		public Task Process(TRequest request, CancellationToken cancellationToken)
		{
			string requestName = typeof(TRequest).Name;
			// var userId = _currentUserService.UserId ?? string.Empty;
			var userName = string.Empty;

			//if (!string.IsNullOrEmpty(userId))
			//{
			//	userName = await _identityService.GetUserNameAsync(userId);
			//}

			//_logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName, request);
			_logger.LogInformation("CleanArchitecture Request: {Name} {@UserName} {@Request}", requestName, userName, request);

			return Task.CompletedTask;
		}
	}
}