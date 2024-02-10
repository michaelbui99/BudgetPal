using System.Text.Json.Serialization;

namespace API.Controllers.V1.Users.Accounts.Dtos;

public class CreateAccountDto
{
    [JsonPropertyName("userId")]
    public Guid UserId{ get; set; }

    [JsonPropertyName("name")]
    public string Name{ get; set; }
    
    [JsonPropertyName("initialBalance")]
    public double InitialBalance{ get; set; }
 
    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }
}