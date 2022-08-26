using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;

namespace webapp.Controllers
{
    public class CalculadoraController : Controller
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }
    public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(Calculadora objCalculadora)
        {
            double resultado1 = 0.0;
            double resultado2 = 0.0;
            double resultado3 = 0.0;
            
            if(objCalculadora.Operando =="+"){
                resultado1 = objCalculadora.Operador1 + objCalculadora.Operador2;
                resultado2 = resultado1 * 0.18;
                resultado3 = resultado1 + resultado2;
            }

            ViewData["Message0"] = "Producto: "+ objCalculadora.Producto;
            ViewData["Message00"] = "El peso es: "+ objCalculadora.peso;
            ViewData["Message1"] = "El resultado base es: "+ resultado1;
            ViewData["Message2"] = "El IGV es: "+ resultado2;
            ViewData["Message3"] = "Total: "+ resultado3;
            return View("Index");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}