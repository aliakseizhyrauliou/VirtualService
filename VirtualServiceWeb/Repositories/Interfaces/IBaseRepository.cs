using VirtualServiceWeb.Data.Models;

namespace VirtualServiceWeb.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseModel
{
    bool Any();

    Task<T> GetByIdAsync(string id);

    Task<List<T>> GetAllAsync();

    void Add(T model);

    Task AddAsync(T model);

    Task<bool> TryAddAsync(T model);

    void AddList(List<T> models);

    Task AddListAsync(List<T> models);

    Task UpdateAsync(T model);

    Task DeleteAsync(T model);

    Task DeleteByIdAsync(string id);

}