using AutoMapper;

using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.Execucao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Resposta;

namespace ThomasGregChallenge.Application.Test.AdicionarCliente
{
    public class AdicionarClienteHandlerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IExecucaoAdicionarCliente> _fluxoAddClienteMock;
        private AdicionarClienteHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _fluxoAddClienteMock = new Mock<IExecucaoAdicionarCliente>();
            _handler = new AdicionarClienteHandler(_mapperMock.Object, _fluxoAddClienteMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsGuid()
        {
            // Arrange
            var command = new AdicionarClienteCommand
            {
                Nome = "Teste Nome",
                Email = "teste@exemplo.com",
                LogotipoBase64 = "123456789"
            };

            var requisicao = new RequisicaoAdicionarCliente
            {
                Nome = command.Nome,
                Email = command.Email,
                LogotipoBase64 = command.LogotipoBase64
            };

            var resposta = new RespostaAdicionarCliente
            {
                IdCliente = Guid.NewGuid()
            };

            _mapperMock.Setup(m => m.Map<AdicionarClienteCommand, RequisicaoAdicionarCliente>(It.IsAny<AdicionarClienteCommand>()))
                       .Returns(requisicao);

            _fluxoAddClienteMock.Setup(f => f.Processar(It.IsAny<RequisicaoAdicionarCliente>()))
                                .Returns(resposta);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(resposta.IdCliente, result);
        }
    }
}
