using Core.Models.Common;

namespace Core.Models;

public enum CurrencyCode
{
    Dkk,
    Usd,
    Gbp,
    Eur,
}

public class Currency: ValueObject
{
    public CurrencyCode Code { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}