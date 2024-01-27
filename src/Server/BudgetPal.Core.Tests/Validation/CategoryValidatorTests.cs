using Core.Models;
using Core.Validation;
using Core.Validation.Validators;

namespace Core.Tests.Validation;

[TestFixture]
public class CategoryValidatorTests
{
    [Test]
    public void Validate_CategoryNameIsEmpty_ResturnsResultWithSingleViolation()
    {
        // Arrange
        Category category = new()
        {
            Name = null,
            AssignedAmount = new MoneyAmount(1000, CurrencyCode.Dkk)
        };
        CategoryValidator validator = new();

        // Act
        ValidatorResult<Category> results = validator.Validate(category);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(results.HasViolations, Is.True);
            Assert.That(results.Results.Keys.Count, Is.EqualTo(1));
        });
    }
}