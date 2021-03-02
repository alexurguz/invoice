using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Entities;
using Invoice.Core.Interfaces.UseCase;
using Invoice.Core.Interfaces.Repository;
using Invoice.Core.Interfaces.UnitOfWork;

namespace Invoice.Core.UseCase
{
    public class UserUseCaseImpl : IUserUseCase
    {

        private readonly IUnitOfWork _unitOfWork;
        public UserUseCaseImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task InsertUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        
    }
}
