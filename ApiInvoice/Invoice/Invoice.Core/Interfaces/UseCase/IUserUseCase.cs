using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Entities;

namespace Invoice.Core.Interfaces.UseCase
{
    public interface IUserUseCase
    {
        IEnumerable<User> GetUsers();
        Task<User> GetUserById(int id);
        Task InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
