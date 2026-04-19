using BookStore.Application.DTOs;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Policies;

namespace BookStore.Application.Services;

public class PromotionAppService
{
    private readonly PromotionPolicy _policy;
    private readonly IUserRepository _userRepo;
    private readonly IBookRepository _bookRepo;

    public PromotionAppService(
        PromotionPolicy policy,
        IUserRepository userRepo,
        IBookRepository bookRepo)
    {
        _policy = policy;
        _userRepo = userRepo;
        _bookRepo = bookRepo;
    }

    public bool CheckPromotion(PromotionCheckRequest request)
    {
        var user = _userRepo.GetById(request.UserId);
        var books = _bookRepo.GetByIds(request.BookIds);

        if (user == null)
            return false;

        var now = DateTime.Now;
        var storeOpen = DateTime.Now.AddMonths(-3);

        return _policy.IsEligible(user, books, now, storeOpen);
    }
}