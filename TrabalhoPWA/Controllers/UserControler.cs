using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet.Cliente;
using Buffet.ViewModels.Home;

namespace Buffet.ControllersS
{
    public class UserController : Controller
    {
        private readonly ILogger<Controller> _logger;
        private readonly ClienteService _clienteService;
        private readonly DatabaseContext _databaseContext;

        public UserController(ILogger<UserController> logger ,  ClienteService clienteService, DatabaseContext databaseContext)
        {
            _clienteService = clienteService;
            _databaseContext = databaseContext;
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
    
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Cadastro()
        {
            return View();
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