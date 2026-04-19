using BookStore.Application.DTOs;
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

    public bool CheckPromotion(PromotionCheckRequest request)
    {
        // 🔥 mock data (ตอนนี้ยังไม่ใช้ DB)
        var user = new User
        {
            Id = request.UserId,
            Subscription = true
        };

        var books = request.BookIds.Select(id => new Book
        {
            Id = id,
            Category = BookCategory.Tales // mock ไปก่อน
        }).ToList();

        var now = DateTime.Now;
        var storeOpen = DateTime.Now.AddMonths(-3);

        return _policy.IsEligible(user, books, now, storeOpen);
    }
}