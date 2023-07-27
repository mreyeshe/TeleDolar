// <copyright file="RemesaController.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using API.DTOs;
using API.Services.Remesas;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration;
using System.Net;

namespace API.Controllers;

/// <summary>
/// Remesas CRUD Operations Class.
/// </summary>
[ApiController]
[Route("[controller]")]
public class RemesaController : ControllerBase
{
    /// <summary>
    /// Property Logger.
    /// </summary>
    private readonly ILogger<RemesaController> logger;

    /// <summary>
    /// 
    /// </summary>
    private readonly RemesaService service;

    /// <summary>
    /// Initializes a new instance of the <see cref="IndexModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    public RemesaController(ILogger<RemesaController> logger, RemesaService service) => (this.logger, this.service) = (logger, service);

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRemesaRequest request)
    {
        try
        {
            var users = await service.CreateAsync(request);

            return this.Ok(users);
        }
        catch (WebException ex)
        {
            this.logger.LogError(ex.InnerException.Message);

            return this.StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int Id)
    {
        var users = await this.service.GetAsync(Id);

        return this.Ok(users);
    }
}