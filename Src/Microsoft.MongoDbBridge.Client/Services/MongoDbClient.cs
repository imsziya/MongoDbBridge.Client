using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.MongoDbBridge.Client.Contracts;
using Microsoft.MongoDbBridge.Client.DbContexts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Microsoft.MongoDbBridge.Client.Services
{
	public class MongoDbClient<T> : IMongoDbClient<T> where T : IEntity
	{
		private readonly MongoDbContext<T> _context;
		public MongoDbClient(MongoDbContext<T> context)
		{
			_context = context;
		}
		public async Task CreateAsync(T entity) => await _context.Collection.InsertOneAsync(entity);

		public async Task CreateManyAsync(List<T> entities) => await _context.Collection.InsertManyAsync(entities);

		public async Task DeleteAsync(string id) => await _context.Collection.DeleteOneAsync(e => e.Id == ObjectId.Parse(id));
		public async Task<List<T>> GetAllAsync() => await _context.Collection.Find(_ => true).ToListAsync();
		public async Task<T> GetAsync(string id) => await _context.Collection.Find(e => e.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
		public async Task UpdateAsync(string id, T entity) => await _context.Collection.ReplaceOneAsync(e => e.Id == ObjectId.Parse(id), entity);
	}
}
