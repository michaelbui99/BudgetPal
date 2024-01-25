namespace Core.Models.NeededBy;

public interface INeededBy
{
    DateTimeOffset GetNextDate(DateTimeOffset fromTime);
}