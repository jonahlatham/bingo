using Bingo.data;
using Bingo.Data.Entities;

namespace Bingo.Services
{
    public interface IAdminService
    {
        void PostAdmin(Admin admin);
    }
    public class AdminService : IAdminService
    {
        private CoreContext _context;
        public AdminService(CoreContext context)
        {
            _context = context;
        }
        public void PostAdmin(Admin admin)
        {
            var results = _context.Admin.Add(new Admin()
            {
                UserId = admin.UserId,
                GameId = admin.GameId
            });
            _context.SaveChanges();
        }
    }
}