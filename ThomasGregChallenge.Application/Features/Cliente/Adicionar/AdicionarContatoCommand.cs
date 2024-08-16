using MediatR;

using System.ComponentModel.DataAnnotations;

namespace ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente
{
    public class AdicionarClienteCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Base64String(ErrorMessage = "O logotipo precisa ser uma string no formato base64.")]
        [StringLength(273067, ErrorMessage = "O tamanho do logotipo não pode exceder o equivalente a 200 KB.")]
        public string LogotipoBase64 { get; set; }
    }
}
