using System.Text.Json.Serialization;

namespace API.Dtos;

public class ApiResponse<T>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("errors")]
    public IDictionary<string, IReadOnlyCollection<string>>? Errors { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }
}