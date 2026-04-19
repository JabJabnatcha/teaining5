using Xunit;
using BookStore.Application.DTOs;

namespace BookStore.Tests.Application;

public class PromotionDtoTests
{
    [Fact]
    public void Should_Have_DefaultValues()
    {
        var dto = new PromotionCheckRequest();

        Assert.NotNull(dto.BookIds);
        Assert.Empty(dto.BookIds);
    }

    [Fact]
    public void Should_Accept_UserAndBooks()
    {
        var dto = new PromotionCheckRequest
        {
            UserId = 1,
            BookIds = new List<int> { 1, 2, 3 }
        };

        Assert.Equal(1, dto.UserId);
        Assert.Equal(3, dto.BookIds.Count);
    }
}