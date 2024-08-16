
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ThomasGregChallenge.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public LoginModel(ILogger<LoginModel> logger, IConfiguration configuration, HttpClient httpClientService)
        {
            _httpClient = httpClientService;
            _configuration = configuration;
            _logger = logger;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Cria o objeto de login para enviar para a API
            var loginData = new { Email, Password };

            var enderecoApi = _configuration["EnderecoApi"];
            var timeoutApi = _configuration.GetValue<int>("TimeoutApi");

            var jsonContent = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

            // Chama a API para autenticação
            var response =  _httpClient.PostAsync($"{enderecoApi}/auth/login", jsonContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var authToken = JsonSerializer.Deserialize<AuthTokenResponse>(responseContent);

                var token = JsonDocument.Parse(responseContent).RootElement.GetProperty("token").GetString();

                HttpContext.Session.SetString("Token", token);

                return RedirectToPage("/Clientes");
            }
            else
            {
                var errorContent = response.Content.ReadAsStringAsync().Result;
                // Lida com erros de autenticação
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }

        public class AuthTokenResponse
        {
            public string Token { get; set; }
        }
    }
}
