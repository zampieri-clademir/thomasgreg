using AutoMapper;

using ThomasGregChallenge.Application.Dto.Cliente;

namespace ThomasGregChallenge.API.Features.Cliente
{
    public class ClienteControllerMapper : Profile
    {
        public ClienteControllerMapper()
        {
            CreateMap<ClienteDto, RetornoClientesViewModel>();
        }
    }
}

