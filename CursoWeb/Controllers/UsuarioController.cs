using CursoWeb.Models.Usuario;
using CursoWeb.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace CursoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _iUsuarioService;
        public UsuarioController(IUsuarioService iUserServices)
        {
            _iUsuarioService = iUserServices;
        }

        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput)
        {

            //var clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            //var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://localhost:5011/");
            //var json = JsonConvert.SerializeObject(registrarUsuarioViewModelInput);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //var httpPost = httpClient.PostAsync("/api/v1/Usuario/registrar", httpContent).GetAwaiter().GetResult();
            //if (httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            //{
            //    //ViewBag.Mensagem = "Os dados foram cadastrado com sucesso";
            //    ModelState.AddModelError("", "Os dados foram cadastrado com sucesso");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Erro ao cadastrar " + httpPost.RequestMessage);
            //}

            try
            {
                var resultado = await _iUsuarioService.Registrar(registrarUsuarioViewModelInput);
                ModelState.AddModelError("", "blz ao cadastrar ");

            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar(LoginViewModelInput loginViewModelInput)
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                var usuario = await _iUsuarioService.Logar(loginViewModelInput);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Usuario.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Usuario.Login),
                    new Claim(ClaimTypes.Email, usuario.Usuario.Email),
                    new Claim("token", usuario.Token),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1))
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                ModelState.AddModelError("", $"O usuário está autenticado {usuario.Token}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return View();
        }
    }

}
