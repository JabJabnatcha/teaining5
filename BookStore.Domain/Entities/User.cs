namespace BookStore.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public bool Subscription { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}