using Application.Behaviours;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
		{
			services
				.AddAutoMapper(Assembly.GetExecutingAssembly())
				.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
				.AddMediatR(Assembly.GetExecutingAssembly())
				.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>))
				.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
				.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

			return services;
		}
	}
}