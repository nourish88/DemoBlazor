using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IAuthService
    {
        Task Login(LoginModel loginModel);
        Task Logout();
    }
}
