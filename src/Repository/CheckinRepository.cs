using Core;
using MongoDB.Driver;
using Repository.Initialization;

namespace Repository;

public class CheckinRepository : BaseRepository<Checkin>
{
    public CheckinRepository(MongoClient client) : base(client)
    {
        var checkins = InitializationHelper.Deserialize<Checkin[]>(Resource.Checkins).Where(checkin => !Collection.Find(c => c.Id == checkin.Id).Any());

        foreach (var checkin in checkins)
        {
            Collection.InsertOne(checkin);
        }
    }

    public Task<IEnumerable<Checkin>> GetCheckinsOnMostRecentDate()
    {
        var newestCheckin = Collection.Find(checkin => true).SortByDescending(checkin => checkin.Timestamp).First();
        var mostRecentDate = newestCheckin.Timestamp.Date;

        return GetCheckinsOnDate(mostRecentDate);
    }

    public async Task<IEnumerable<Checkin>> GetCheckinsOnDate(DateTime date)
    {
        var results = await Collection.FindAsync(checkin =>
            checkin.Timestamp >= date
            && checkin.Timestamp < date.AddDays(1));

        return results.ToEnumerable();
    }
}
