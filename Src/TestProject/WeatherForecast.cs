using Microsoft.MongoDbBridge.Client.Contracts;
using MongoDB.Bson;

namespace TestProject
{
	public class WeatherForecast : WeatherForecastDto, IEntity
	{      
		public ObjectId Id { get; set ; } = ObjectId.GenerateNewId();
	}

	public partial class WeatherForecastDto
	{
		public string? DocumentId { get; set; }
		public int TemperatureC { get; set; }
		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
		public DateTime Date { get; set; }
		public string? Summary { get; set; }
	}
}
