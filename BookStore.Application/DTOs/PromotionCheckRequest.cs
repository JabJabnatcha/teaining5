namespace BookStore.Application.DTOs;

public class PromotionCheckRequest
{
    public int UserId { get; set; }
    public List<int> BookIds { get; set; } = new();
}