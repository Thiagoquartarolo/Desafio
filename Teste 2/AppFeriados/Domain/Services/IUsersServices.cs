using AppFeriados.Domain.Models;

namespace AppFeriados.Domain.Services
{
    public interface IUsersServices
    {
        User GetById(User user);
    }
}
