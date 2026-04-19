using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IUserRepository
{
    User? GetById(int id);
}