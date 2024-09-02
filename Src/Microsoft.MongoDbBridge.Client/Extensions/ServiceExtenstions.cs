using Microsoft.Extensions.DependencyInjection;
using Microsoft.MongoDbBridge.Client.Contracts;
using Microsoft.MongoDbBridge.Client.DbContexts;
using Microsoft.MongoDbBridge.Client.Services;

namespace Microsoft.MongoDbBridge.Client.Extensions
{
	public static class ServiceExtenstions
	{
		public static IServiceCollection AddMongoService<T>(this IServiceCollection services,string connString,string database) where T : IEntity
		{
			services.AddSingleton(_ =>
			{
				return new MongoDbContext<T>(connString, database);
			});
			services.AddScoped<IMongoDbClient<T>, MongoDbClient<T>>();
			return services;
		}

	}

}
