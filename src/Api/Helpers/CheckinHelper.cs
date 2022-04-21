using Core;
using Repository;

namespace Api.Helpers;

public class CheckinHelper
{
    private readonly CheckinRepository _checkinRepository;

    public CheckinHelper(CheckinRepository checkinRepository)
    {
        _checkinRepository = checkinRepository;
    }

    public async Task<Dictionary<string, List<Checkin>>> GetCheckinsOnMostRecentDate()
    {
        var checkins = await _checkinRepository.GetCheckinsOnMostRecentDate();
        return GetCheckinsByUserId(checkins);
    }

    public async Task<Dictionary<string, List<Checkin>>> GetCheckinsOnDate(DateTime date)
    {
        var checkins = await _checkinRepository.GetCheckinsOnDate(date);
        return GetCheckinsByUserId(checkins);
    }

    private Dictionary<string, List<Checkin>> GetCheckinsByUserId(IEnumerable<Checkin> checkins)
    {
        var result = new Dictionary<string, List<Checkin>>();
        foreach (var checkin in checkins)
        {
            if (!result.TryGetValue(checkin.SlackUserId, out var _))
            {
                result[checkin.SlackUserId] = new List<Checkin>();
            }

            result[checkin.SlackUserId].Add(checkin);
        }

        return result;
    }
}
