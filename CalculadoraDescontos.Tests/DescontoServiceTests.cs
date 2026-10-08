using CalculadoraDescontos;
using Xunit;

namespace CalculadoraDescontos.Tests;

public class DescontoServiceTests
{
    private readonly DescontoService _service;

    public DescontoServiceTests()
    {
        _service = new DescontoService();
    }

    [Theory]
    [InlineData(2, "BRONZE")]
    [InlineData(7, "PRATA")]
    [InlineData(15, "OURO")]
    public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(
        int totalCompras,
        string categoriaEsperada)
    {
        // Act
        var resultado = _service.ObterCategoriaCliente(totalCompras);

        // Assert
        Assert.Equal(categoriaEsperada, resultado);
    }

    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 20, 160)]
    [InlineData(50, 0, 50)]
    public void CalcularDescontoPorPercentual_DeveRetornarValorCorreto(
        int valorOriginal,
        int percentualDesconto,
        int valorEsperado)
    {
        // Act
        var resultado = _service.CalcularDescontoPorPercentual(
            valorOriginal,
            percentualDesconto);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    [Theory]
    [InlineData(20, false, true)]
    [InlineData(16, true, true)]
    [InlineData(17, false, false)]
    public void EValidoParaCupom_DeveRetornarResultadoCorreto(
        int idade,
        bool primeiraCompra,
        bool resultadoEsperado)
    {
        // Act
        var resultado = _service.EValidoParaCupom(
            idade,
            primeiraCompra);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
}