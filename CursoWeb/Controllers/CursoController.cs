using CursoWeb.Models.Curso;
using Microsoft.AspNetCore.Mvc;

namespace CursoWeb.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            return View();
        }

        public IActionResult Listar()
        {
            var cursos = new List<ListarCursoViewModelOutput>();

            for (int i = 0; i < 5; i++)
            {
                cursos.Add(new ListarCursoViewModelOutput()
                {
                    Nome = "Curso " + i,
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
