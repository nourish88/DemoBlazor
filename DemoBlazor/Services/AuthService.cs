using Blazor.Extensions.Storage;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace DemoBlazor.Services
{
    public class AuthService:IAuthService
    {
        private HttpClient _http;
        private LocalStorage _localStorage;
        public bool IsLoggedIn { get; private set; }
        public AuthService(HttpClient http, LocalStorage localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }
        public async Task Login(LoginModel loginModel)
        {
            var response = await _http.PostJsonAsync<TokenModel>("https://localhost:44355/api/auth/login", loginModel);
            if (!String.IsNullOrEmpty(response.Token))
            {
                await _localStorage.SetItem("token", response.Token);
                await SetAuthorizationHeader();

                IsLoggedIn = true;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItem("token");
            IsLoggedIn = false;
        }


        private async Task SetAuthorizationHeader()
        {
            if (!_http.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await _localStorage.GetItem<string>("token");
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
