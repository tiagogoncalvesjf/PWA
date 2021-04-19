using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrabalhoPWA.Models.Acesso;

namespace TrabalhoPWA.Controllers
{
    public class AcessoService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _user_signInManager;

        public AcessoService(UserManager<User> userManager, SignInManager<User> userSignInManager)
        {
            _userManager = userManager;
            _user_signInManager = userSignInManager;
        }


        public async Task AutenticarUsuario (string email, string senha)
        {
            var resultado = await _user_signInManager.PasswordSignInAsync(email, senha, false, false);
            
            if (!resultado.Succeeded)
            {
                throw new("Usuario ou senha inválidos !");
            }
            
        }




        public async Task RegistrarUsuario(string email, string senha)
        {
            var novoUsuario = new User()
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(novoUsuario, senha);

            if (!resultado.Succeeded)
            {
                var listaErros = "";
                foreach (var identityError in resultado.Errors)
                {
                    listaErros += identityError.Description + " - ";
                }

                throw new Exception(listaErros);
            }


        }






    }
}


//lembrar de adicionar o novo serviço no startup !