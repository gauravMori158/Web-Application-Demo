using WebdevelopmentDemo.Interface;
using WebdevelopmentDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace WebdevelopmentDemo.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly DbContextClass _context;
        public UserRepo(DbContextClass context)
        {
            _context = context;
        }

        public List<User> GetAlluser()
        {
           return _context.Users.Include(d=>d.Roles).ToList();
        }
    }
}
