using Core.Serialization;
using System.Text.Json.Serialization;

namespace Core;

public class Checkin
{
    public string Id { get; set; } = null!;

    [JsonConverter(typeof(UnixDateTimeJsonConverter))]
    public DateTime Timestamp { get; set; }

    public string Elaboration { get; set; } = null!;

    public string Emotion { get; set; } = null!;

    public string? MeetingHours { get; set; }

    public string Platform { get; set; } = null!;

    public string? PrivateElaboration { get; set; }

    public Reactions? Reactions { get; set; }

    public Selection Selection { get; set; }

    public string? SlackMessageId { get; set; }

    public string SlackOrgId { get; set; } = null!;

    public string SlackTeamId { get; set; } = null!;

    public string SlackUserId { get; set; } = null!;
}
