using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Forecasts.Queries
{
	public class GetForecastValidator : AbstractValidator<GetForecast>
	{
		public GetForecastValidator()
		{
			RuleFor(v => v.Postcode)
				.NotNull().WithMessage("Postcode cannot be null.")
				.NotEmpty().WithMessage("Postcode is required.")
				.MaximumLength(4).WithMessage("Postcode must not exceed 4 characters.")
				.MustAsync(BeNumeric).WithMessage("The postcode must be numeric");
		}

		public async Task<bool> BeNumeric(string postcode, CancellationToken cancellationToken)
		{
			return await Task.FromResult(postcode?.All(char.IsDigit) ?? false);
		}
	}
}