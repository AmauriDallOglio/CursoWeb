using CursoWeb.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CursoWeb.Services
{
    public interface IUsuarioService
    {
        [Post("/api/v1/Usuario/registrar")]
        Task<RegistrarUsuarioViewModelInput> Registrar(RegistrarUsuarioViewModelInput input);


        [Post("/api/v1/usuario/logar")]
        Task<LoginViewModelOutput> Logar(LoginViewModelInput loginViewModelInput);
    }
}
