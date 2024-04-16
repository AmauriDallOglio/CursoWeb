using CursoWeb.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CursoWeb.Services
{
    public interface IUsuarioService
    {
        [Post("/api/v1/Usuario/Registrar")]
        Task<RegistrarUsuarioViewModelInput> Registrar(RegistrarUsuarioViewModelInput input);


        [Post("/api/v1/Usuario/Logar")]
        Task<LoginViewModelOutput> Logar(LoginViewModelInput loginViewModelInput);
    }
}
