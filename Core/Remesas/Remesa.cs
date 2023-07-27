// <copyright file="Remesa.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

namespace Core.Remesas;

/// <summary>
/// Remesas Obj Model.
/// </summary>
public partial class Remesa : BaseEntity<int>
{
    /// <summary>
    /// Gets or sets sender name.
    /// </summary>
    /// <value>
    /// The sender name.
    /// </value>
    public string NombreRemitente { get; set; }

    /// <summary>
    /// Gets or sets beneficiary name.
    /// </summary>
    /// <value>
    /// The beneficiary name.
    /// </value>
    public string NombreBeneficiario { get; set; }

    /// <summary>
    /// Gets or sets amount remittance.
    /// </summary>
    /// <value>
    /// The amount remittance.
    /// </value>
    public decimal Monto { get; set; }

    /// <summary>
    /// Gets or sets Creation Date.
    /// </summary>
    /// <value>
    /// The Creation Date.
    /// </value>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Gets or sets Code for Country origin.
    /// </summary>
    /// <value>
    /// The Code Country Origin.
    /// </value>
    public string CodigoPaisOrigen { get; set; }

    /// <summary>
    /// Gets or sets Code for Country Destination.
    /// </summary>
    /// <value>
    /// The Code Country Destination.
    /// </value>
    public string CodigoPaisDestino { get; set; }

    /// <summary>
    /// Gets or sets Code for Currency Code.
    /// </summary>
    /// <value>
    /// The Code Currency Code.
    /// </value>
    public string CodigoMoneda { get; set; }
}