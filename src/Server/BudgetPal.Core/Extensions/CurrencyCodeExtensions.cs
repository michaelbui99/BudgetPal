using Core.Models;

namespace Core.Extensions;

public static class CurrencyCodeExtensions
{
    public static CurrencyCode ToCurrencyCode(this string code)
    {
        return code.ToLowerInvariant() switch
        {
            "dkk" => CurrencyCode.Dkk,
            "usd" => CurrencyCode.Usd,
            "gbp" => CurrencyCode.Gbp,
            "eur" => CurrencyCode.Eur,
            _ => throw new ArgumentException($"Invalid currency code {code}")
        };
    }
}