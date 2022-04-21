using MongoDB.Driver;

namespace Repository;

public abstract class BaseRepository<T>
{
    protected IMongoCollection<T> Collection;

    protected BaseRepository(MongoClient client)
    {
        var database = client.GetDatabase("TrafficLightCheckin");
        Collection = database.GetCollection<T>(typeof(T).Name);
    }
}
