namespace Core.Models;

public static class CurrencyExtensions
{
    public static string ToCodeString(this CurrencyCode code)
    {
        return code switch
        {
            CurrencyCode.Dkk => "DKK",
            CurrencyCode.Eur => "EUR",
            CurrencyCode.Gbp => "GBP",
            CurrencyCode.Usd => "USD",
            _ => throw new ArgumentException($"Unsupported code {code}")
        };
    }

    public static string ToSymbol(this CurrencyCode code)
    {
        return code switch
        {
            CurrencyCode.Dkk => "DKK",
            CurrencyCode.Eur => "€",
            CurrencyCode.Gbp => "£",
            CurrencyCode.Usd => "$",
            _ => throw new ArgumentException($"Unsupported code {code}")
        };
    }
}