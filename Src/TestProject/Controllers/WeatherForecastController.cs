using Microsoft.AspNetCore.Mvc;
using Microsoft.MongoDbBridge.Client.Contracts;
using MongoDB.Bson;

namespace TestProject.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController(IMongoDbClient<WeatherForecast> dbClient) : ControllerBase
	{
		[HttpPost(Name = "GetWeatherForecast")]
		public async Task<IActionResult> Set(WeatherForecastDto weather)
		{
			await dbClient.CreateAsync(new WeatherForecast
			{
				Id = ObjectId.GenerateNewId(),
				Date = weather.Date,
				Summary = weather.Summary,
				TemperatureC = weather.TemperatureC
			});
			return Accepted();
		}

		[HttpGet(Name = "GetWeatherForecast")]
		[ProducesResponseType(typeof(IEnumerable<WeatherForecastDto>), StatusCodes.Status200OK)]
		public IActionResult GetAll()
		{
			var data = dbClient.GetAllAsync().Result.Select(item => new WeatherForecastDto
			{
				DocumentId = item.Id.ToString(),
				Date = item.Date,
				Summary = item.Summary,
				TemperatureC = item.TemperatureC
			});
			return Ok(data);
		}

		[HttpGet("GetWeatherForecast/{id}")]
		public async Task<IActionResult> Get(string id)
		{
			var item = await dbClient.GetAsync(id);
			return Ok(new WeatherForecastDto
			{
				DocumentId = item.Id.ToString(),
				Date = item.Date,
				Summary = item.Summary,
				TemperatureC = item.TemperatureC
			});
		}

		[HttpPut("GetWeatherForecast/{id}")]
		public async Task<IActionResult> Update(string id, WeatherForecastDto request)
		{
			var entity = await dbClient.GetAsync(id);
			if(entity == null) return NoContent();
			entity.Date = request.Date;
			entity.Summary = request.Summary;
			entity.TemperatureC = request.TemperatureC;
			await dbClient.UpdateAsync(id, entity);
			return Ok("entity updated");
		}

		[HttpDelete("GetWeatherForecast/{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			var entity = await dbClient.GetAsync(id);
			if (entity == null) return NoContent();			
			await dbClient.DeleteAsync(id);
			return Ok("entity deleted");
		}
	}
}
