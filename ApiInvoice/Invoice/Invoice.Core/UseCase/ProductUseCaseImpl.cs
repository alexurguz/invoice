using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Entities;
using Invoice.Core.Interfaces.UseCase;
using Invoice.Core.Interfaces.Repository;
using Invoice.Core.Interfaces.UnitOfWork;

namespace Invoice.Core.UseCase
{
    public class ProductUseCaseImpl : IProductUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductUseCaseImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task InsertProduct(Product product)
        {
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
