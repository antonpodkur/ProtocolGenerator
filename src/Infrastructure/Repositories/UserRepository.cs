using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ProtocolGeneratorDbContext _context;

        public UserRepository(ProtocolGeneratorDbContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.User.Add(user);
            user.Id = _context.SaveChanges();
            return user;
        }
    }
}