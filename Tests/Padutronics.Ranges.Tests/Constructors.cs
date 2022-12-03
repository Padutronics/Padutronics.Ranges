using NUnit.Framework;
using System;

namespace Padutronics.Ranges.Tests;

[TestFixture]
internal sealed class Constructors
{
    [Test]
    public void Lower_bound_is_included_if_not_specified()
    {
        // Arrange.

        // Act.
        var range = new Range<int>(5, 10);

        // Assert.
        Assert.That(range.IsLowerBoundIncluded, Is.True);
    }

    [Test]
    public void Upper_bound_is_included_if_not_specified()
    {
        // Arrange.

        // Act.
        var range = new Range<int>(5, 10);

        // Assert.
        Assert.That(range.IsUpperBoundIncluded, Is.True);
    }

    [Test]
    public void Exception_is_thrown_if_lower_bound_is_greater_than_upper_one()
    {
        // Arrange.

        // Act.
        static void Action() => new Range<int>(6, 5);

        // Assert.
        Assert.That(Action, Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Exception_is_not_thrown_if_bounds_are_equal_and_included()
    {
        // Arrange.

        // Act.
        static void Action() => new Range<int>(5, 5, isLowerBoundIncluded: true, isUpperBoundIncluded: true);

        // Assert.
        Assert.That(Action, Throws.Nothing);
    }

    [Test]
    public void Exception_is_thrown_if_bounds_are_equal_but_only_lower_one_is_included()
    {
        // Arrange.

        // Act.
        static void Action() => new Range<int>(5, 5, isLowerBoundIncluded: true, isUpperBoundIncluded: false);

        // Assert.
        Assert.That(Action, Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Exception_is_thrown_if_bounds_are_equal_but_only_upper_one_is_included()
    {
        // Arrange.

        // Act.
        static void Action() => new Range<int>(5, 5, isLowerBoundIncluded: false, isUpperBoundIncluded: true);

        // Assert.
        Assert.That(Action, Throws.TypeOf<ArgumentException>());
    }
}