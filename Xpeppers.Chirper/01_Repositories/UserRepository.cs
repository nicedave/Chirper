using System.Collections.Generic;
using System.Linq;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class UserRepository : IUserRepository
    {
        private IChirperContext _context;

        public UserRepository(IChirperContext context)
        {
            _context = context;
        }

        public IUser Find(string UserName)
        {
            if (_context.Users == null)
            {
                return null;
            }

            return _context.Users.SingleOrDefault(u => u.Name.ToUpper() == UserName.ToUpper());
        }

        public IUser Add(string UserName)
        {
            if (_context.Users == null)
            {
                _context.Users = new List<IUser>();
            }

            IUser newUser = new User(UserName);
            _context.Users.Add(newUser);

            return newUser;
        }

        public void Save(IUser user)
        {
            IUser oldUser = _context.Users.SingleOrDefault(u => u.Name == user.Name);
            oldUser = user;
        }
    }
}
