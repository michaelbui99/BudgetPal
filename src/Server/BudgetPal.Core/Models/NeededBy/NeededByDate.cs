namespace Core.Models.NeededBy;

public class NeededByDate : INeededBy
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int DayOfMonth { get; set; }
    public bool Recurrent { get; set; }

    public DateTimeOffset GetNextDate(DateTimeOffset fromTime)
    {
        DateTimeOffset nextDate = new(Year, Month, DayOfMonth, 0, 0, 0, TimeSpan.Zero);
        if (fromTime <= nextDate || !Recurrent)
        {
            return nextDate;
        }

        DateTimeOffset nextInYear = new(fromTime.Year, Month, DayOfMonth, 0, 0, 0, TimeSpan.Zero);
        return fromTime > nextInYear ? nextInYear.AddYears(1) : nextInYear;
    }
}