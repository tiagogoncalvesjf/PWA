using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public UserController(ILogger<UserController> logger ,  ClienteService clienteService)
        {
            _clienteService = clienteService;
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
                    Nome = clienteEntity.Nome
                });
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