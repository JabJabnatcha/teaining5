using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;

namespace BookStore.Infrastructure;

public class FakeUserRepository : IUserRepository
{
    public User? GetById(int id)
    {
        return new User
        {
            Id = id,
            Subscription = true
        };
    }
}