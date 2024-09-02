using Microsoft.Extensions.DependencyInjection;
using Microsoft.MongoDbBridge.Client.Contracts;
using Microsoft.MongoDbBridge.Client.DbContexts;
using Microsoft.MongoDbBridge.Client.Services;

namespace Microsoft.MongoDbBridge.Client.Extensions
{
	public static class ServiceExtenstions
	{
		/// <summary>
		/// Add the dependencies of the mongo serices
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="services"></param>
		/// <param name="connString"></param>
		/// <param name="database"></param>
		/// <returns></returns>
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
