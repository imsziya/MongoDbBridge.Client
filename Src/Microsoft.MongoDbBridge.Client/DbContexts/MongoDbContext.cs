using Microsoft.MongoDbBridge.Client.Contracts;
using MongoDB.Driver;

namespace Microsoft.MongoDbBridge.Client.DbContexts
{
	public class MongoDbContext<T> where T : IEntity
	{
		private readonly IMongoDatabase _database;

		public MongoDbContext(string connectionString, string databaseName)
		{
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(databaseName);
		}

		public IMongoCollection<T> Collection => _database.GetCollection<T>(typeof(T).Name);
	}

	

}
