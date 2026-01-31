using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.WebAssembly.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAuthor();
        Task<Response<AuthorDetailsDto>> GetAuthor(int id);
        Task<Response<AuthorUpdateDto>> GetForUpdateAuthor(int id);
        Task<Response<int>> CreateAuthor(AuthorCreateDto author);
        Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author);
        Task<Response<int>> Delete(int id);
    }
}