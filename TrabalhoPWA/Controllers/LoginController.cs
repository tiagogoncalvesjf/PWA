using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet.Cliente;

namespace Buffet.ControllersS
{
    public class LoginController : Controller
    {
        private readonly ILogger<Controller> _logger;

        public LoginController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
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