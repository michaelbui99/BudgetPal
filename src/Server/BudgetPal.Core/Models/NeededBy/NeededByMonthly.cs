namespace Core.Models.NeededBy;

public class NeededByMonthly : INeededBy
{
    private bool _isNeededByEndOfMonth;
    private bool _isNeededByBeginningOfMonth;

    public bool IsNeededByEndOfMonth
    {
        get => _isNeededByEndOfMonth;
        set
        {
            _isNeededByEndOfMonth = value;
            if (_isNeededByBeginningOfMonth && _isNeededByEndOfMonth)
            {
                throw new ArgumentException(
                    "Monthly target cannot be needed by end of month if already needed by beginning of month");
            }
        }
    }

    public bool IsNeededByBeginningOfMonth
    {
        get => _isNeededByBeginningOfMonth;
        set
        {
            _isNeededByBeginningOfMonth = value;
            if (_isNeededByEndOfMonth && _isNeededByBeginningOfMonth)
            {
                throw new ArgumentException(
                    "Monthly target cannot be needed by beginning of month if already needed by end of month");
            }
        }
    }

    public int DayOfMonth { get; set; }

    public DateTimeOffset GetNextDate(DateTimeOffset fromTime)
    {
        if (IsNeededByBeginningOfMonth)
        {
            return fromTime.Day == 1
                ? new DateTimeOffset(fromTime.Year, fromTime.Month, 1, 0, 0, 0, TimeSpan.Zero)
                : new DateTimeOffset(fromTime.Year, fromTime.AddMonths(1).Month, 1, 0, 0, 0, TimeSpan.Zero);
        }

        if (IsNeededByEndOfMonth)
        {
            return new DateTimeOffset(fromTime.Year, fromTime.Month,
                DateTime.DaysInMonth(fromTime.Year, fromTime.Month), 0, 0, 0, TimeSpan.Zero);
        }

        int nextMonth = fromTime.Month;
        // If it has already passed the configured day in the month, the next month should be used.
        if (fromTime.Day > DayOfMonth)
        {
            nextMonth += 1;
        }

        return new DateTimeOffset(fromTime.Year, nextMonth, DayOfMonth, 0, 0, 0, TimeSpan.Zero);
    }
}