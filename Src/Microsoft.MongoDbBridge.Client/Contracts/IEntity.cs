using MongoDB.Bson;

namespace Microsoft.MongoDbBridge.Client.Contracts
{
	public interface IEntity
	{
		public ObjectId Id { get; set; }
	}
}
