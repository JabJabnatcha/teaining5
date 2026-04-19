using BookStore.Domain.Entities;
using BookStore.Domain.Enums;
using BookStore.Domain.Interfaces;

namespace BookStore.Infrastructure;

public class FakeBookRepository : IBookRepository
{
    public List<Book> GetByIds(List<int> ids)
    {
        return ids.Select(id => new Book
        {
            Id = id,
            Category = BookCategory.Tales
        }).ToList();
    }
}