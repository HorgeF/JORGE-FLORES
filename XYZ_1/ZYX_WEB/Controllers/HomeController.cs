using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZYX_WEB.Models;

namespace ZYX_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }    
        
        public IActionResult Productos()
        {
            return View();
        }
        public IActionResult Pedidos()
        {
            return View();
        }

		public IActionResult NuevoPedido(int accion , int id_pedido)
		{
            ViewBag.accion = accion;
            ViewBag.id_pedido = id_pedido;
            return View();
		}
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
