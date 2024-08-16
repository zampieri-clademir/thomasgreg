using Moq;

using NUnit.Framework;

using ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente;
using ThomasGregChallenge.Domain.Entidades.Cliente;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Contexto;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.PersistirDados;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Repositorio;

namespace ThomasGregChallenge.Domain.Test.AdicionarCliente
{
    [TestFixture]
    public class AdicionarClientePersistirDadosImplTests
    {
        private Mock<IRepositorioCliente> _repositorioMock;
        private PersistirDadosAdicionarClienteImpl _persistirDados;

        [SetUp]
        public void SetUp()
        {
            _repositorioMock = new Mock<IRepositorioCliente>();
            _persistirDados = new PersistirDadosAdicionarClienteImpl(_repositorioMock.Object);
        }

        [Test]
        public void Processar_ValidContext_ReturnsGuid()
        {
            // Arrange
            var contexto = new ContextoAdicionarCliente
            {
                Requisicao = new RequisicaoAdicionarCliente
                {
                    Nome = "Teste Nome",
                    Email = "teste@exemplo.com",
                    LogotipoBase64 = "123456789"
                }
            };

            var expectedGuid = 1;
            _repositorioMock.Setup(r => r.SalvarAsync(It.IsAny<ClienteVO>())).ReturnsAsync(expectedGuid);

            // Act
            var result = _persistirDados.Processar(contexto);

            // Assert
            Assert.Greater(expectedGuid, result);
        }
    }
}
