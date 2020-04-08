using System.Net.Http;
using System.Threading.Tasks;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Services
{
    public class CategoryService:ICategoryService
    {
        private HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }
        public Task<Category[]> GetCategories()
        {
            return _http.GetJsonAsync<Category[]>("https://localhost:44355/api/categories/getall");
        }
    }
}
