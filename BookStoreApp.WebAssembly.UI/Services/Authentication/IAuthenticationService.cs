using BookStoreApp.WebAssembly.UI.Services.Base;

namespace BookStoreApp.WebAssembly.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        //wrapper
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);

        public Task Logout();
        
    }
}
