namespace BookStore.Domain.Entities;
using BookStore.Domain.Enums;

public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; } = string.Empty;
    public string Writer { get; set; } = string.Empty;
    public double Price { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
    public BookCategory Category { get; set; }
}