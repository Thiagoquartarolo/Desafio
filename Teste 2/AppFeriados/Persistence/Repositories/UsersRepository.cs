using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Repository;

namespace AppFeriados.Persistence.Repositories
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context)
        { }

        public User GetById(User user)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == user.Id && x.Password == user.Password );
        }
    }
}