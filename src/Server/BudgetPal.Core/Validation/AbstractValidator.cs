namespace Core.Validation;

public abstract class AbstractValidator<T>
{
    private readonly ICollection<Rule<T>> _rules = new List<Rule<T>>();

    public ValidatorResult Validate(T entity)
    {
        ValidatorResult results = new ValidatorResult();

        foreach (var rule in _rules)
        {
            RuleValidationResult result = rule.Validate(entity);
            if (!result.IsValid)
            {
                results.Results.Add(result.ViolatedRule!, result.Errors!.ToList());
                results.HasViolations = true;
            }
        }

        return results;
    }

    public void AddRule(Func<T, bool> constraint, string? name = "", string? message = "")
    {
        if (string.IsNullOrEmpty(name))
        {
            var type = GetType().UnderlyingSystemType;
            name = type.Name;
        }

        Rule<T> rule = new(name, constraint)
        {
            ErrorMessages = message != null ? new List<string> { message } : new List<string>()
        };

        _rules.Add(rule);
    }

    public void AddRule(Func<T, bool> constraint, string? name = "",
        IReadOnlyCollection<string>? messages = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            var type = GetType().UnderlyingSystemType;
            name = type.Name;
        }

        Rule<T> rule = new(name, constraint)
        {
            ErrorMessages = messages != null ? messages.ToList() : new List<string>()
        };

        _rules.Add(rule);
    }
}