// <copyright file="RepositoryBase.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Infrastructure.Data.Repositories;

/// <summary>
/// Base repository class.
/// </summary>
/// <typeparam name="T">T model.</typeparam>
public class RepositoryBase<T> : IAsyncRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<T> dbSet;

    public RepositoryBase(EFContext dbContext)
    {
        this.dbSet = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await this.dbSet.AddAsync(entity);
        return entity;
    }

    public Task<bool> DeleteAsync(T entity)
    {
        this.dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return this.dbSet.FirstOrDefaultAsync(expression);
    }

    public Task<T> UpdateAsync(T entity)
    {
        this.dbSet.Update(entity);
        return Task.FromResult(entity);
    }
}