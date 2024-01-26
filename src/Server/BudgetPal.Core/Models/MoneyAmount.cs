using Core.Models.Common;

namespace Core.Models;

public class MoneyAmount : ValueObject
{
    public Currency Currency { get; set; }
    public double Amount { get; set; }


    public MoneyAmount(double amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static MoneyAmount NewDefault()
    {
        return new MoneyAmount(0, new Currency { Code = Defaults.DefaultCurrencyCode });
    }

    public string ToSymbolString()
    {
        return $"{Amount} {Currency.Code.ToSymbol()}";
    }

    public override string ToString()
    {
        return $"{Amount} {Currency.Code.ToCodeString()}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency.Code;
    }
}