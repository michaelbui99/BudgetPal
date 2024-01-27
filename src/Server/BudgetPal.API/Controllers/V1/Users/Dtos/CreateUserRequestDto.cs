using System.Text.Json.Serialization;

namespace API.Controllers.V1.Dtos;

public class CreateUserRequestDto
{
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }
}