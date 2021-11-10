using System.Linq;
using Bingo.data;
using Bingo.Data.Entities;

namespace Bingo.Services
{
    public interface IUserService
    {
        void PostUser(User user);
    }
    public class UserService : IUserService
    {
        private CoreContext _context;
        public UserService(CoreContext context)
        {
            _context = context;
        }
        public void PostUser(User user)
        {
            var isThere = _context.User.FirstOrDefault(e => e.Name == user.Name);
            if (isThere==null)
            {
                var results = _context.User.Add(new User()
                {
                    Name = user.Name,
                    Password = user.Password
                });
                _context.SaveChanges();
            }
        }
    }
}