using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet.Cliente;
using Buffet.RequestModel;
using Buffet.ViewModel;
using Buffet.ViewModels.Home;
using TrabalhoPWA.Controllers;

namespace Buffet.ControllersS
{
    public class Public : Controller
    {
        private readonly ILogger<Controller> _logger;
        private readonly ClienteService _clienteService;
        private readonly DatabaseContext _databaseContext;
        private readonly AcessoService _acessoService;


        public Public(ILogger<Public> logger ,  ClienteService clienteService, DatabaseContext databaseContext, AcessoService acessoService)
        {
            _clienteService = clienteService;
            _databaseContext = databaseContext;
            _acessoService = acessoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewmodel = new IndexViewModel();
            
            var clientesDoBanco = _clienteService.ObterClientes();
            
            foreach (var clienteEntity in clientesDoBanco) {
                viewmodel.Clientes.Add(new Cliente()
                {
                    Id = clienteEntity.Id.ToString(),
                    Cpf = clienteEntity.Cpf,
                    Nome = clienteEntity.Nome,
                    
                });
            }

            var clienteEspecifico = _databaseContext.Clientes.Single(c => c.Nome.Equals("Tiago"));

            viewmodel.clienteEspecificoTeste = clienteEspecifico;
            
            if(clienteEspecifico != null)
            Console.WriteLine("Nome " + clienteEspecifico.Nome);
            else
            {
                Console.WriteLine("Não Encontrado");
            }
            

            return View(viewmodel);
        }
    
        [HttpGet]
        public IActionResult Login()
        {
            var viewmodel = new LoginViewModel();
            viewmodel.Mensagem = (string)TempData["msg-cadastro"];
            return View(viewmodel);
        }
        
        [HttpPost]
        public async Task <RedirectResult> Login(UsuarioLoginRequestModel request)
        {

            var email = request.Email;
            var senha = request.Senha;
            
            
            try
            {
                await _acessoService.AutenticarUsuario(email, senha);
                return Redirect("/Usuario/Secao");
            }
            catch (Exception exception)
            {
                TempData["msg-cadastro"] = exception.Message;
                return Redirect("/Public/Login");
            }
            
        }
        
        
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Cadastro()
        {
            var viewmodel = new CadastroViewModel();
            viewmodel.Mensagem = (string)TempData["msg-cadastro"];
            return View(viewmodel);
        }
        
        [HttpPost]
        public async Task <RedirectResult> Cadastro(UsuarioCadastrarRequestModel request)
        {
            var redirectUrl = "/Public/Cadastro";

            var email = request.Email;
            var senha = request.Senha;
            var senhaConfirmacao = request.SenhaConfirmacao;

            if (email == null)
            {
                //TempData = Container de dados temporário que tem como duracao o request 
                TempData["msg-cadastro"] = "Por favor informe o endereço de email";
                return Redirect(redirectUrl);
            }

            try
            {
                await _acessoService.RegistrarUsuario(email, senha);
                TempData["msg-cadastro"] = "Cadastro realizado com sucesso, efetue o login";
                return Redirect("/Public/Login");
            }
            catch (Exception exception)
            {
                TempData["msg-cadastro"] = exception.Message;
                return Redirect("/Public/Cadastro");
            }
            
            return Redirect(redirectUrl);
        }
        
        public IActionResult Recuperacao()
        {
            return View();
        }
        
        public IActionResult Termos()
        {
            return View();
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}