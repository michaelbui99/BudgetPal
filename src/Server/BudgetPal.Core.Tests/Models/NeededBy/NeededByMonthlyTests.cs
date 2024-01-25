using Core.Models.NeededBy;

namespace Core.Tests.Models.NeededBy;

[TestFixture]
public class NeededByMonthlyTests
{
    [Test]
    public void GetNextDate_NowIsPastTheBeginningOfMonthAndIsNeededByBeginningOfMonth_ReturnsBeginingOfNextMonth()
    {
        // Arrange
        DateTimeOffset now = new DateTimeOffset(2023, 1, 2, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByMonthly
        {
            IsNeededByEndOfMonth = false,
            IsNeededByBeginningOfMonth = true,
            DayOfMonth = 1
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(2));
            Assert.That(nextDate.Day, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void GetNextDate_NowIsBeginingOfMonthAndIsNeededByBeginningOfMonth_ReturnsBeginningOfCurrentMonth()
    {
        // Arrange
        DateTimeOffset now = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByMonthly
        {
            IsNeededByEndOfMonth = false,
            IsNeededByBeginningOfMonth = true,
            DayOfMonth = 1
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void GetNextDate_NowIsJanuaryAndIsNeededByEnd_ReturnsEndOfJanuary()
    {
        // Arrange
        DateTimeOffset now = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByMonthly
        {
            IsNeededByEndOfMonth = true,
            IsNeededByBeginningOfMonth = false,
            DayOfMonth = 1
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(31));
        });
    }

    [Test]
    public void GetNextDate_NowIsPastTargetDayInMonth_ReturnsTargetDayInNextMonth()
    {
        // Arrange
        DateTimeOffset now = new DateTimeOffset(2023, 1, 15, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByMonthly
        {
            IsNeededByEndOfMonth = false,
            IsNeededByBeginningOfMonth = false,
            DayOfMonth = 14 
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(2));
            Assert.That(nextDate.Day, Is.EqualTo(14));
        });
    }
    
    [Test]
    public void GetNextDate_NowIsPriorToTargetDayInMonth_ReturnsTargetDayInCurrentMonth()
    {
        // Arrange
        DateTimeOffset now = new DateTimeOffset(2023, 1, 13, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByMonthly
        {
            IsNeededByEndOfMonth = false,
            IsNeededByBeginningOfMonth = false,
            DayOfMonth = 14 
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(14));
        });
    }
}