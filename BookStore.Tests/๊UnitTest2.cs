using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using BookStore.API;
using Xunit;

namespace BookStore.Tests;

public class APIServiceTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public APIServiceTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task POST_CheckPromotion_ShouldReturn200()
    {
        // Act
        var response = await _client.PostAsync("/api/promotion/check", null);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task POST_CheckPromotion_ShouldReturnTrue()
    {
        // Act
        var result = await _client.PostAsync("/api/promotion/check", null);

        var value = await result.Content.ReadFromJsonAsync<bool>();

        // Assert
        Assert.True(value);
    }
}