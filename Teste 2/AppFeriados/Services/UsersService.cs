using AppFeriados.Domain.Models;
using AppFeriados.Domain.Repository;
using AppFeriados.Domain.Services;

namespace AppFeriados.Services
{
    public class UsersService : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetById(User user)
        {
            return _usersRepository.GetById(user);
        }
    }
}
