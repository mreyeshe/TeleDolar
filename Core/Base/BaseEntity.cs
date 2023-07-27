// <copyright file="BaseEntity.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Core.Base;

/// <summary>
/// Base entity class.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Base domain events.
    /// </summary>
    private List<BaseDomainEvent> events;

    /// <summary>
    /// Readonly list events.
    /// </summary>
    public IReadOnlyList<BaseDomainEvent> Events => this.events.AsReadOnly();

    protected void AddEvent(BaseDomainEvent @event)
    {
        this.events.Add(@event);
    }

    protected void RemoveEvent(BaseDomainEvent @event)
    {
        this.events.Remove(@event);
    }
}

/// <summary>
/// Base enity abstract class.
/// </summary>
/// <typeparam name="TKey">return Tkey.</typeparam>
public abstract class BaseEntity<TKey> : BaseEntity
{
    public TKey Id { get; set; }
}
