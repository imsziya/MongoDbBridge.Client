using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.MongoDbBridge.Client.Contracts
{
	public interface IMongoDbClient<T> where T : IEntity
	{	
		Task<List<T>> GetAllAsync();
		Task<T> GetAsync(string id);
		Task CreateAsync(T entity);
		Task CreateManyAsync(List<T> entities);
		Task DeleteAsync(string id);
		Task UpdateAsync(string id,T entity);
	}
}
