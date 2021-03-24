using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet.Cliente;


namespace Buffet.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        
        public IActionResult Ajuda()
        {
            return View();
        }
        
        public IActionResult PainelUsuario()
        {
            return View();
        }
        
        public IActionResult Seção()
        {
            return View();
        }
        
        public IActionResult LogOut()
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