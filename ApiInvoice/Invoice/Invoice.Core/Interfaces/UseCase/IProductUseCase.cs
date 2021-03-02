using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Entities;

namespace Invoice.Core.Interfaces.UseCase
{
    public interface IProductUseCase
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProductById(int id);
        Task InsertProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
