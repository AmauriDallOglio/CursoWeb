using System.ComponentModel.DataAnnotations;

namespace CursoWeb.Models.Curso
{
    public class ListarCursoViewModelOutput
    {
        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A desrição é obrigatória")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login {  get; set; }
    }
}
