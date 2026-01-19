using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> GetBooks();
        Task<Response<BookDetailsDto>> GetBook(int id);
        Task<Response<BookUpdateDto>> GetForUpdateBook(int id);
        Task<Response<int>> CreateBook(BookCreateDto author);
        Task<Response<int>> EditBook(int id, BookUpdateDto author);
        Task<Response<int>> Delete(int id);
    }
}