using BookStore.Domain.Entities;
using BookStore.Domain.Enums;
using BookStore.Domain.Policies;

namespace BookStore.Application.Services;

public class PromotionAppService
{
    private readonly PromotionPolicy _policy;

    public PromotionAppService(PromotionPolicy policy)
    {
        _policy = policy;
    }

    public bool CheckPromotion()
    {
        var user = new User
        {
            Subscription = true
        };

        var books = new List<Book>
        {
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales },
            new Book { Category = BookCategory.Fables },
            new Book { Category = BookCategory.Tales }
        };

        var now = DateTime.Now;
        var storeOpen = DateTime.Now.AddMonths(-3);

        return _policy.IsEligible(user, books, now, storeOpen);
    }
}