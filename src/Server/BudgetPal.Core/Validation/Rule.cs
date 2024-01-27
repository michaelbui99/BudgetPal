namespace Core.Validation;

public class Rule<T>
{
    public string Name { get; set; }
    public Func<T, bool> Constraint { get; set; }
    public ICollection<string> ErrorMessages { get; set; } = new List<string>();

    public Rule(string name, Func<T, bool> constraint)
    {
        Name = name;
        Constraint = constraint;
    }

    public RuleValidationResult Validate(T entity)
    {
        if (Constraint.Invoke(entity))
        {
            return RuleValidationResult.Success();
        }

        return new RuleValidationResult
        {
            IsValid = false,
            Errors = ErrorMessages.ToList(),
            ViolatedRule = Name
        };
    }
}