using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

using ThomasGregChallenge.API.Features.Cliente;
using ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente;

namespace ThomasGregChallenge.API.Test.Controlador
{
    [TestFixture]
    public class ClienteControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IMapper> _mapperMock;
        private ClienteController _controller;

        [SetUp]
        public void SetUp()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ClienteController(_mediatorMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task AdicionarCliente_ValidRequest_ReturnsOk()
        {
            // Arrange
            var ClienteCommand = new AdicionarClienteCommand { Nome = "Teste", Email = "teste@exemplo.com", LogotipoBase64 = "123456789" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AdicionarClienteCommand>(), default)).ReturnsAsync(Guid.NewGuid());

            // Act
            var result = await _controller.AdicionarCliente(ClienteCommand);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOf<Guid>(okResult.Value);
        }

        [Test]
        public async Task AdicionarCliente_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Nome", "O nome é obrigatório");
            var ClienteCommand = new AdicionarClienteCommand();

            // Act
            var result = await _controller.AdicionarCliente(ClienteCommand);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
