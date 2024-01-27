namespace Core.Validation;

public class RuleValidationResult
{
    public bool IsValid { get; set; } = false;
    public string? ViolatedRule { get; set; }
    public IReadOnlyCollection<string>? Errors { get; set; }

    public static RuleValidationResult Success()
    {
        RuleValidationResult result = new()
        {
            IsValid = true,
            Errors = new List<string>(),
            ViolatedRule = null
        };
        return result;
    }
}