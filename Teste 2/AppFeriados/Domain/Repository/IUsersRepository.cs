using AppFeriados.Domain.Models;

namespace AppFeriados.Domain.Repository
{
    public interface IUsersRepository
    {
        User GetById(User user);
    }
}
