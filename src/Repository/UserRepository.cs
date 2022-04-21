using Core;
using MongoDB.Driver;
using Repository.Initialization;

namespace Repository;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(MongoClient client) : base(client)
    {
        var newUsers = InitializationHelper.Deserialize<User[]>(Resource.Users).Where(user => !Collection.Find(u => u.Id == user.Id).Any());
        foreach (var user in newUsers)
        {
            Collection.InsertOne(user);
        }
    }

    public async Task<User?> GetUser(string id)
    {
        return (await Collection.FindAsync(x => x.Id == id)).SingleOrDefault();
    }

    public IEnumerable<User> GetUsers()
    {
        return Collection.AsQueryable().OrderBy(x => x.Id);
    }
}
