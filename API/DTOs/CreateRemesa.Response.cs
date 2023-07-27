// <copyright file="CreateRemesa.Request.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace API.DTOs;

/// <summary>
/// Create Remesa OutPut Model.
/// </summary>
public class CreateRemesaResponse
{
    /// <summary>
    /// Gets or sets response Message.
    /// </summary>
    /// <value>
    /// The response message.
    /// </value>
    [Required]
    [StringLength(50)]
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets response Message.
    /// </summary>
    /// <value>
    /// The response message.
    /// </value>
    [Required]
    [StringLength(50)]
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether response is success for petition.
    /// </summary>
    /// <value>
    /// The validation of success response.
    /// </value>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets a Id register.
    /// </summary>
    /// <value>
    /// The Id from db.
    /// </value>
    public int Id { get; set; }
}