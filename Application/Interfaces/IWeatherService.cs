using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
	public interface IWeatherService
	{
		Task<IEnumerable<Forecast>> Forecast(string postcode);
	}
}