using System.ComponentModel.DataAnnotations;

namespace CursoWeb.Models.Curso
{
    public class CadastrarCursoViewModelInput
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A desrição é obrigatória")]
        public string Descricao { get; set; }
    }
}
