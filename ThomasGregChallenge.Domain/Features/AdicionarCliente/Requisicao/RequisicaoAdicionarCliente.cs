namespace ThomasGregChallenge.Domain.Features.AdicionarCliente.Requisicao
{
    public class RequisicaoAdicionarCliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string LogotipoBase64 { get; set; }
    }
}
