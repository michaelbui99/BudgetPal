using Core.Models;

namespace Core.Validation.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        AddRule(category => category.AssignedAmount.Amount >= 0, "CategoryAssignedAmount",
            "Category cannot be assigned a amount of money that is less than 0");
        AddRule(category => !string.IsNullOrEmpty(category.Name), "CategoryNameNotNull", "Category cannot have null or empty name" );
    }
}