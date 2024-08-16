using AutoMapper;

using ThomasGregChallenge.Application.Dto.Cliente;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao;
using ThomasGregChallenge.Domain.Features.AdicionarCliente.Resposta;

namespace ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente
{
    public class AdicionarClienteApplicationMapper : Profile
    {
        public AdicionarClienteApplicationMapper()
        {
            CreateMap<AdicionarClienteCommand, RequisicaoAdicionarCliente>();
            CreateMap<RespostaAdicionarCliente, ClienteDto>();
        }
    }
}
