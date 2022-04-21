namespace Core;

public class UnixDateTime
{
    public static DateTime ToDateTime(double unixTimeStamp)
    {
        return DateTime.UnixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
    }

    public static double ToUnixDateTime(DateTime dateTime)
    {
        return dateTime.Subtract(DateTime.UnixEpoch).TotalSeconds;
    }
}
