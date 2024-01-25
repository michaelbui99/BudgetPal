using Core.Models.NeededBy;

namespace Core.Tests.Models.NeededBy;

[TestFixture]
public class NeededByDateTests
{
    [Test]
    public void GetNextDate_NowIsPastDateInYearAndIsRecurrent_ReturnsDateInNextYear()
    {
        // Arrange    
        DateTimeOffset now = new DateTimeOffset(2023, 1, 13, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByDate
        {
            Year = 2023,
            Month = 1,
            DayOfMonth = 12,
            Recurrent = true
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(12));
            Assert.That(nextDate.Year, Is.EqualTo(2024));
        });
    }

    [Test]
    public void GetNextDate_NowIsBeforeDate_ReturnsConfiguredDateAsNext()
    {
        // Arrange    
        DateTimeOffset now = new DateTimeOffset(2023, 1, 10, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByDate
        {
            Year = 2023,
            Month = 1,
            DayOfMonth = 12,
            Recurrent = true
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(12));
            Assert.That(nextDate.Year, Is.EqualTo(2023));
        });
    }

    [Test]
    public void
        GetNextDate_NowIsPastOriginalDateButPriorToNextDateInCurrentYearAndRecurrent_ReturnsConfiguredDateWithCurrentYearAsNext()
    {
        // Arrange    
        DateTimeOffset now = new DateTimeOffset(2024, 1, 10, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByDate
        {
            Year = 2023,
            Month = 1,
            DayOfMonth = 12,
            Recurrent = true
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(12));
            Assert.That(nextDate.Year, Is.EqualTo(2024));
        });
    }
    
    [Test]
    public void
        GetNextDate_NowIsPastOriginalDateAndPastNextDateINYearAndRecurrent_ReturnsDateInNextYearAsNext()
    {
        // Arrange    
        DateTimeOffset now = new DateTimeOffset(2024, 1, 13, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByDate
        {
            Year = 2023,
            Month = 1,
            DayOfMonth = 12,
            Recurrent = true
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(12));
            Assert.That(nextDate.Year, Is.EqualTo(2025));
        });
    }
    
    [Test]
    public void
        GetNextDate_NowIsPastOriginalDateAndNotRecurrent_ReturnsOriginalDateAsNext()
    {
        // Arrange    
        DateTimeOffset now = new DateTimeOffset(2024, 1, 13, 0, 0, 0, TimeSpan.Zero);
        INeededBy neededBy = new NeededByDate
        {
            Year = 2023,
            Month = 1,
            DayOfMonth = 12,
            Recurrent = false
        };
        
        // Act
        DateTimeOffset nextDate = neededBy.GetNextDate(now);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(nextDate.Month, Is.EqualTo(1));
            Assert.That(nextDate.Day, Is.EqualTo(12));
            Assert.That(nextDate.Year, Is.EqualTo(2023));
        });
    }
}