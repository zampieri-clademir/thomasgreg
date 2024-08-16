using AutoMapper;

using MediatR;

using ThomasGregChallenge.Domain.Features.AdicionarCliente.Modulos.Execucao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Resposta;

namespace ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente
{
    public class AdicionarClienteHandler : IRequestHandler<AdicionarClienteCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IExecucaoAdicionarCliente _fluxoAddCliente;

        public AdicionarClienteHandler(IMapper mapper, IExecucaoAdicionarCliente fluxoAddCliente)
        {
            _fluxoAddCliente = fluxoAddCliente;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            var requisicao = _mapper.Map<AdicionarClienteCommand, RequisicaoAdicionarCliente>(request);

            var resposta = await ExecutarFluxoProcessamento(requisicao);

            return resposta.IdCliente;
        }

        private async Task<RespostaAdicionarCliente> ExecutarFluxoProcessamento(RequisicaoAdicionarCliente requisicao)
        {
            var resposta = _fluxoAddCliente.Processar(requisicao);

            return await Task.FromResult(resposta);
        }
    }
}
