using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GenericRepository(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            var enitity = await GetAsync(id);
            context.Set<T>().Remove(enitity);
            await context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync() 
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            context.Update(entity);
            return context.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<VertualizeResponse<IResult>> GetAllAsync<IResult>(QueryParameters queryParam) where IResult : class
        {
            var totalSize = await context.Set<T>().CountAsync();
            var items = await context.Set<T>()
                .Skip(queryParam.StartIndex)
                .Take(queryParam.PageSize)
                .ProjectTo<IResult>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new VertualizeResponse<IResult> { Items = items, TotalSize = totalSize };
        }
    }
}
