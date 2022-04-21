using Api.Helpers;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckinController : ControllerBase
{
    private readonly CheckinHelper _checkinHelper;

    public CheckinController(
        CheckinHelper checkinRepository)
    {
        _checkinHelper = checkinRepository;
    }

    [HttpGet(Name = "GetCheckins")]
    public async Task<Dictionary<string, List<Checkin>>> Get([FromQuery] string? date = null)
    {
        return DateTime.TryParse(date, out var parsedDate)
            ? await _checkinHelper.GetCheckinsOnDate(parsedDate)
            : await _checkinHelper.GetCheckinsOnMostRecentDate();
    }
}
