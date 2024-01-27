using Core.Models.Common;

namespace Core.Models;

public class MoneyAmount : ValueObject
{
    public CurrencyCode CurrencyCode { get; set; }
    public double Amount { get; set; }


    public MoneyAmount(double amount, CurrencyCode currencyCode)
    {
        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public MoneyAmount()
    {
        // For EF
    }

    public static MoneyAmount NewDefault()
    {
        return new MoneyAmount(0, Defaults.DefaultCurrencyCode);
    }

    public string ToSymbolString()
    {
        return $"{Amount} {CurrencyCode.ToSymbol()}";
    }

    public override string ToString()
    {
        return $"{Amount} {CurrencyCode.ToCodeString()}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return CurrencyCode;
    }
}