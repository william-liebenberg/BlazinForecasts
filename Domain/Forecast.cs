using System;

namespace Domain
{
	public class Forecast
	{
		public DateTime Date { get; set; }

		public int Temperature { get; set; }

		public string Summary { get; set; } = string.Empty;
	}
}