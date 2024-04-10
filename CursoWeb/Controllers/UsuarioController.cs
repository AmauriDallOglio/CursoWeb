using CursoWeb.Models.Usuario;
using CursoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Net.Http;
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
            //var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://localhost:5011/");

            //// Serializando o objeto para JSON
            //var json = JsonConvert.SerializeObject(registrarUsuarioViewModelInput);
            //// Criando um objeto StringContent com o conteúdo JSON
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

        public IActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return View();
        }
    }

}
