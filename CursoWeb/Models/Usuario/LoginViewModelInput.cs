using System.ComponentModel.DataAnnotations;

namespace CursoWeb.Models.Usuario
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O senha é obrigatório")]
        public string Senha { get; set; }
    }
}
