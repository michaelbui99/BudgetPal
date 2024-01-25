namespace Core.Models;

public enum CurrencyCode
{
    Dkk,
    Usd,
    Gbp,
    Eur,
}

public class Currency
{
    public CurrencyCode Code { get; set; }
}