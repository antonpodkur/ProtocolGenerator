using Infrastructure.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
    }
}