using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public BookService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateBook(BookCreateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksPOSTAsync(author);
            }
            catch (ApiException apiException)
            {
                response = ConvertAPIExeptions<int>(apiException);
            }
            return response;
        }

        public async Task<Response<List<BookReadOnlyDto>>> GetBook()
        {
            Response<List<BookReadOnlyDto>> response;
            try
            {
                await GetBearerToken();
                var data = await client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertAPIExeptions<List<BookReadOnlyDto>>(apiException);
            }
            return response;
        }

        public async Task<Response<BookDetailsDto>> GetBook(int id)
        {
            Response<BookDetailsDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertAPIExeptions<BookDetailsDto>(apiException);
            }
            return response;
        }

        public async Task<Response<int>> EditBook(int id, BookUpdateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksPUTAsync(id, author);
            }
            catch (ApiException apiException)
            {
                response = ConvertAPIExeptions<int>(apiException);
            }
            return response;
        }

        public async Task<Response<BookUpdateDto>> GetForUpdateBook(int id)
        {
            Response<BookUpdateDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(id);
                response = new Response<BookUpdateDto>
                {
                    Data = mapper.Map<BookUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertAPIExeptions<BookUpdateDto>(apiException);
            }
            return response;
        }

        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.BooksDELETEAsync(id);

            }
            catch (ApiException apiException)
            {
                response = ConvertAPIExeptions<int>(apiException);
            }
            return response;
        }
    }
}
