using NUnit.Framework;

namespace Padutronics.Ranges.Tests;

[TestFixture]
internal sealed class Contains
{
    [Test]
    public void Range_contains_value_that_is_greater_than_lower_bound_and_less_than_upper_bound()
    {
        // Arrange.
        var range = new Range<int>(5, 10);

        // Act.
        bool result = range.Contains(7);

        // Assert.
        Assert.That(result, Is.True);
    }
    [Test]
    public void Range_contains_value_that_is_equal_to_lower_bound_if_lower_bound_is_included()
    {
        // Arrange.
        var range = new Range<int>(5, 10, isLowerBoundIncluded: true, isUpperBoundIncluded: true);

        // Act.
        bool result = range.Contains(5);

        // Assert.
        Assert.That(result, Is.True);
    }

    [Test]
    public void Range_contains_value_that_is_equal_to_upper_bound_if_upper_bound_is_included()
    {
        // Arrange.
        var range = new Range<int>(5, 10, isLowerBoundIncluded: true, isUpperBoundIncluded: true);

        // Act.
        bool result = range.Contains(10);

        // Assert.
        Assert.That(result, Is.True);
    }

    [Test]
    public void Range_does_not_contain_value_that_is_less_than_lower_bound()
    {
        // Arrange.
        var range = new Range<int>(5, 10);

        // Act.
        bool result = range.Contains(4);

        // Assert.
        Assert.That(result, Is.False);
    }

    [Test]
    public void Range_does_not_contain_value_that_is_greater_than_upper_bound()
    {
        // Arrange.
        var range = new Range<int>(5, 10);

        // Act.
        bool result = range.Contains(11);

        // Assert.
        Assert.That(result, Is.False);
    }

    [Test]
    public void Range_does_not_contain_value_that_is_equal_to_lower_bound_if_lower_bound_is_not_included()
    {
        // Arrange.
        var range = new Range<int>(5, 10, isLowerBoundIncluded: false, isUpperBoundIncluded: true);

        // Act.
        bool result = range.Contains(5);

        // Assert.
        Assert.That(result, Is.False);
    }

    [Test]
    public void Range_does_not_contain_value_that_is_equal_to_upper_bound_if_upper_bound_is_not_included()
    {
        // Arrange.
        var range = new Range<int>(5, 10, isLowerBoundIncluded: true, isUpperBoundIncluded: false);

        // Act.
        bool result = range.Contains(10);

        // Assert.
        Assert.That(result, Is.False);
    }
}