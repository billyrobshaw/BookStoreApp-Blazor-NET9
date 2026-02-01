using BookStoreApp.API.Data;
using BookStoreApp.API.Models;
using Microsoft.AspNetCore.Http;

namespace BookStoreApp.API.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);

        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);

        Task<VertualizeResponse<IResult>> GetAllAsync<TResult>(QueryParameters queryParam) where TResult : class;
    }
}
