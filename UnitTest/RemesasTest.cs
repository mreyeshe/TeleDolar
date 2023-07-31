// <copyright file="RemesasTest.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using API.Common.Mappings;
using API.Controllers;
using API.DTOs;
using API.Services.Remesas;
using AutoMapper;
using Castle.Core.Logging;
using Core.Interfaces;
using Core.Remesas;
using Moq;
using System.Linq.Expressions;

namespace UnitTest;

/// <summary>
/// Clases test for remesas operations.
/// </summary>
public class RemesasTest
{
    /// <summary>
    /// Mock for repository Remesas.
    /// </summary>
    private Mock<IRemesasRepository> remesaRepository;

    /// <summary>
    /// Mock for repository Remesas.
    /// </summary>
    private Mock<IAsyncRepository<Remesa>> asyncRepository;

    /// <summary>
    /// Mock for logger.
    /// </summary>
    private Mock<ILogger> logger;

    /// <summary>
    /// Mock for Unit Of Work.
    /// </summary>
    private Mock<IUnitOfWork> unitOfWork;

    /// <summary>
    /// Automapper obj.
    /// </summary>
    private IMapper automapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemesasTest"/> class.
    /// Constructor.
    /// </summary>
    public RemesasTest()
    {
        this.SetUpMocks();
    }

    /// <summary>
    /// Test For new remesa must Ok result.
    /// </summary>
    [Fact]
    public void WhenCreateRemesa_ThenReturnOK()
    {
        // Arrange
        var testModel = this.FillCreateRemesaModel();

        var remesaService = new RemesaService(this.unitOfWork.Object, this.automapper);

        var result = remesaService.CreateAsync(testModel).Result;

        Assert.NotNull(result);
        Assert.Empty(result.ErrorMessage);
        Assert.True(result.Success);
    }

    /// <summary>
    /// Test For Get remesa must Ok result.
    /// </summary>
    [Fact]
    public void WhenGetById_ThenRemesaReturn()
    {
        int idSearch = 1;
        var remesaService = new RemesaService(this.unitOfWork.Object, this.automapper);
        var result = remesaService.GetAsync(idSearch).Result;

        this.remesaRepository.Verify();
        Assert.NotNull(result);
        Assert.Equal(idSearch, result.Id);
    }

    private void SetUpMocks()
    {
        this.logger = new Mock<ILogger>();
        var remesas = this.FillRemesaModel();
        this.automapper = this.GetMapper();
        this.remesaRepository = new Mock<IRemesasRepository>();
        this.remesaRepository.Setup(m => m.GetAsync(_ => _.Id == 1)).Returns(Task.FromResult(remesas)).Verifiable();
        this.unitOfWork = new Mock<IUnitOfWork>();
        this.unitOfWork.Setup(c => c.SaveChangesAsync()).Returns(() => Task.FromResult(1));
        this.unitOfWork.Setup(m => m.AsyncRepository<Remesa>()).Returns(this.remesaRepository.Object);
    }

    private CreateRemesaRequest FillCreateRemesaModel()
    {
        return new CreateRemesaRequest
        {
            CodigoPaisDestino = "MX",
            CodigoMoneda = "USD",
            CodigoPaisOrigen = "US",
            FechaCreacion = DateTime.Now,
            Monto = 1200M,
            NombreBeneficiario = "Miguel Reyes",
            NombreRemitente = "Felipe Rojas",
        };
    }

    private Remesa FillRemesaModel()
    {
        return new Remesa
        {
            CodigoPaisDestino = "MX",
            CodigoMoneda = "USD",
            CodigoPaisOrigen = "US",
            FechaCreacion = DateTime.Now,
            Monto = 1200M,
            NombreBeneficiario = "Miguel Reyes",
            NombreRemitente = "Felipe Rojas",
            Id = 1,
        };
    }

    private IMapper GetMapper()
    {
        var mappingProfile = new RemesasProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
        return new Mapper(configuration);
    }
}