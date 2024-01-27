namespace Core.Validation;

public class ValidatorResult
{
    public IDictionary<string, ICollection<string>> Results { get; set; } =
        new Dictionary<string, ICollection<string>>();

    public bool HasViolations { get; set; } = false;
}