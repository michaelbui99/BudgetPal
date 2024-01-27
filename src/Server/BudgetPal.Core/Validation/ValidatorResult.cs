namespace Core.Validation;

public class ValidatorResult<T>
{
    public IDictionary<string, IReadOnlyCollection<string>> Results { get; set; } =
        new Dictionary<string, IReadOnlyCollection<string>>();

    public bool HasViolations { get; set; } = false;
    public T Entity { get; set; }
}