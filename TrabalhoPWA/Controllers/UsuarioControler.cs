using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet.Cliente;
using Buffet.RequestModel;
using Buffet.ViewModel;

//lembrar de importar !
using Microsoft.AspNetCore.Authorization; 


namespace Buffet.Controllers
{
    
    //Bloqueando acesso para impedir que entrem nestas actions sem estar logado
    [Authorize]
    
    public class Usuario : Controller
    {
        private readonly ILogger<Usuario> _logger;

        public Usuario(ILogger<Usuario> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    
        
        
        
        public IActionResult Privacy()
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
        
        
        public IActionResult Secao()
        {

            return View();
        }
        
        public RedirectResult LogOut()
        {
            return Redirect("/public/login");
        }
        
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}