using System.Text.RegularExpressions;
using Core.Models;

namespace Core.Validation.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        // TODO: Add more rules, e.g. password length checks , dob checks etc.
        AddRule(user => IsValidEmail(user.Email), "ValidEmail", @"Invalid Email. Email must follow pattern ^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    }

    private bool IsValidEmail(string s)
    {
        var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        var matches = regex.IsMatch(s);
        return matches;
    }
}