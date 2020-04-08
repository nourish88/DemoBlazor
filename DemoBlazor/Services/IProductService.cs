using System.Threading.Tasks;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IProductService
    {
        Task<Product[]> GetProducts();
        Task<Product> GetProductById(int productId);
        Task Save(Product product);
        Task Add(Product product);

    }
}
