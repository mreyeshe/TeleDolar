// <copyright file="IAsyncRepository.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Core.Interfaces;

/// <summary>
/// Async Repo Interface.
/// </summary>
/// <typeparam name="T">T object.</typeparam>
public interface IAsyncRepository<T>
    where T : BaseEntity
{
    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T> GetAsync(Expression<Func<T, bool>> expression);
}