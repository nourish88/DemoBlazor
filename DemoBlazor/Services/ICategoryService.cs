using System.Threading.Tasks;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface ICategoryService
    {
        Task<Category[]> GetCategories();
    }
}
