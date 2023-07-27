// <copyright file="BaseDomainEvent.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Core.Base;

/// <summary>
/// Base Domain abstract class.
/// </summary>
public abstract class BaseDomainEvent : INotification
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDomainEvent"/> class.
    /// </summary>
    public BaseDomainEvent()
    {
        this.EventId = Guid.NewGuid();
        this.CreatedOn = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets event Id.
    /// </summary>
    public virtual Guid EventId { get; init; }

    /// <summary>
    /// Gets Created on date.
    /// </summary>
    public virtual DateTime CreatedOn { get; init; }
}