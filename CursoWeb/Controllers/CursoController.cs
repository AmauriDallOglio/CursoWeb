using CursoWeb.Models.Curso;
using CursoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CursoWeb.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _iCursoService;

        public CursoController(ICursoService cursoService)
        {
            _iCursoService = cursoService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            try
            {
                var curso = await _iCursoService.Registrar(cadastrarCursoViewModelInput);

                ModelState.AddModelError("", $"O curso foi cadastrado com sucesso {curso.Nome}");
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

        public IActionResult Listar()
        {
            var cursos = new List<ListarCursoViewModelOutput>();

            for (int i = 0; i < 5; i++)
            {
                cursos.Add(new ListarCursoViewModelOutput()
                {
                    Nome = "(Off) Curso " + i,
                    Descricao = "Descrição do curso " + i,
                    Login = "amauriA"
                });
            }


         
            return View(cursos);
        }

        //[HttpPost]
        //public IActionResult Listar()
        //{
        //    return View();
        //}

    }
}
