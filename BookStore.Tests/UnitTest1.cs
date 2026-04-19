using Xunit;
using BookStore.Domain.Entities;
using BookStore.Domain.Enums;
using BookStore.Domain.Policies;

namespace BookStore.Tests;

// domain tests
public class UnitTest1
{
    [Fact]
    public void Should_NotGetPromotion_When_UserNotSubscribed()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = false };

        var books = new List<Book>
    {
        new Book { Category = BookCategory.Tales },
        new Book { Category = BookCategory.Fables },
        new Book { Category = BookCategory.Tales },
        new Book { Category = BookCategory.Tales },
        new Book { Category = BookCategory.Fables }
    };

        var now = new DateTime(2026, 1, 1);
        var storeOpen = new DateTime(2025, 7, 1);

        var result = policy.IsEligible(user, books, now, storeOpen);

        Assert.False(result);
    }

    [Fact]
    public void Should_NotGetPromotion_When_StoreOlderThan6Months()
    {
        var policy = new PromotionPolicy();

        var user = new User { Subscription = true };

        var books = new List<Book>
    {
        new Book { Category = BookCategory.Tales },
        new Book { Category = BookCategory.Fables },
        new Book { Category = BookCategory.Tales },
        new Book { Category = BookCategory.Tales },
        new Book { Category = BookCategory.Fables }
    };

        var now = new DateTime(2026, 1, 1);
        var storeOpen = new DateTime(2025, 6, 1); // > 6 months

        var result = policy.IsEligible(user, books, now, storeOpen);

        Assert.False(result);
    }
}