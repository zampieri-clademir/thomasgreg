
using Microsoft.AspNetCore.Mvc;

namespace ThomasGregChallenge.API.Base
{
    [Route("api/[controller]")]
    public class PublicController : ControllerBase
    {
        /// <summary>
        /// Informa para o client que est� ativa
        /// �til para validar tokens e para descobrir o estado da API
        /// </summary>
        [HttpGet]
        [Route("is-alive")]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }

    }
}
