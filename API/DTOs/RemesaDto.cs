// <copyright file="RemesaDto.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace API.DTOs;

/// <summary>
/// remesa Dto Model.
/// </summary>
public class RemesaDto
{
    /// <summary>
    /// Gets or sets sender name.
    /// </summary>
    /// <value>
    /// The sender name.
    /// </value>
    [Required]
    [StringLength(50)]
    public string NombreRemitente { get; set; }


    /// <summary>
    /// Gets or sets beneficiary name.
    /// </summary>
    /// <value>
    /// The beneficiary name.
    /// </value>
    [Required]
    [StringLength(50)]
    public string NombreBeneficiario { get; set; }

    /// <summary>
    /// Gets or sets amount remittance.
    /// </summary>
    /// <value>
    /// The amount remittance.
    /// </value>
    [Required]
    public decimal Monto { get; set; }

    /// <summary>
    /// Gets or sets Creation Date.
    /// </summary>
    /// <value>
    /// The Creation Date.
    /// </value>
    [Required]
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Gets or sets Code for Country origin.
    /// </summary>
    /// <value>
    /// The Code Country Origin.
    /// </value>
    [Required]
    [StringLength(50)]
    public string CodigoPaisOrigen { get; set; }

    /// <summary>
    /// Gets or sets Code for Country Destination.
    /// </summary>
    /// <value>
    /// The Code Country Destination.
    /// </value>
    [Required]
    [StringLength(50)]
    public string CodigoPaisDestino { get; set; }

    /// <summary>
    /// Gets or sets Code for Currency Code.
    /// </summary>
    /// <value>
    /// The Code Currency Code.
    /// </value>
    [Required]
    [StringLength(50)]
    public string CodigoMoneda { get; set; }
}