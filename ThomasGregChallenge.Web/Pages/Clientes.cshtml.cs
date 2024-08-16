using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGregChallenge.Domain.Entidades.Cliente;

namespace ThomasGregChallenge.Web.Pages
{
    public class ClientesModel : PageModel
    {
        public List<ClienteVO> Clientes { get; set; }

        public async Task OnGetAsync()
        {
            // Exemplo de clientes estáticos (em uma aplicação real, você buscaria do banco de dados ou API)
            Clientes = new List<ClienteVO>
            {
                new ClienteVO { Id = 1, Nome = "João Silva", Email = "joao@exemplo.com" },
                new ClienteVO { Id = 2, Nome = "Maria Souza", Email = "maria@exemplo.com" },
                new ClienteVO { Id = 3, Nome = "Pedro Santos", Email = "pedro@exemplo.com" }
            };

            // Simulando uma operação assíncrona (exemplo: busca de clientes via API ou banco de dados)
            await Task.CompletedTask;
        }
    }
}
