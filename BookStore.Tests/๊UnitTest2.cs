using Xunit;
using BookStore.Application.Services;
using BookStore.Application.DTOs;
using BookStore.Domain.Policies;

namespace BookStore.Tests.Application;

public class PromotionAppServiceTests
{
    [Fact]
    public void Should_ReturnTrue_When_Eligible()
    {
        var policy = new PromotionPolicy();
        var service = new PromotionAppService(policy);

        var request = new PromotionCheckRequest
        {
            UserId = 1,
            BookIds = new List<int> { 1, 2, 3, 4, 5 }
        };

        var result = service.CheckPromotion(request);

        Assert.True(result);
    }

    [Fact]
    public void Should_ReturnFalse_When_NotEnoughBooks()
    {
        var policy = new PromotionPolicy();
        var service = new PromotionAppService(policy);

        var request = new PromotionCheckRequest
        {
            UserId = 1,
            BookIds = new List<int> { 1, 2 }
        };

        var result = service.CheckPromotion(request);

        Assert.False(result);
    }
}