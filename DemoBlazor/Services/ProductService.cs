using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Services
{
    public class ProductService:IProductService
    {
        private HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
            
        }

        
        public Task<Product[]> GetProducts()
        {
            return _http.GetJsonAsync<Product[]>("https://localhost:44355/api/products/getall");
        }

        public Task<Product> GetProductById(int productId)
        {
            return _http.GetJsonAsync<Product>("https://localhost:44355/api/products/getbyid?productId="+productId);
        }

        public async Task Save(Product product)
        {
            await _http.PostJsonAsync("https://localhost:44355/api/products/update", product);
        }

        public async Task Add(Product product)
        {
            
            await _http.PostJsonAsync("https://localhost:44355/api/products/add", product);
        }
    }
}
