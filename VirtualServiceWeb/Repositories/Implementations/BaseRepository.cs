using Microsoft.EntityFrameworkCore;
using VirtualServiceWeb.Data;
using VirtualServiceWeb.Data.Models;
using VirtualServiceWeb.Repositories.Interfaces;

namespace VirtualServiceWeb.Repositories.Implementations;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet;

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual bool Any()
        {
            return _dbSet.Any();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual void Add(T model)
        {
            _dbSet.Add(model);
            _dbContext.SaveChanges();
        }

        public virtual async Task AddAsync(T model)
        {
            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> TryAddAsync(T model)
        {
            await _dbSet.AddAsync(model);
            int result = await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddList(List<T> models)
        {
            foreach (var model in models)
            {
                Add(model);
            }
        }

        public async Task AddListAsync(List<T> models)
        {
            foreach (var model in models)
            {
                await AddAsync(model);
            }
        }

        public virtual async Task UpdateAsync(T model)
        {
            _dbSet.Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T model)
        {
            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(string id)
        {
            await DeleteAsync(await GetByIdAsync(id));
            await _dbContext.SaveChangesAsync();
        }
    }