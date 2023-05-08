using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Prestamo()
        {
            return View();
        }

        public IActionResult RegistroEstudiante()
        {
            return View();
        }

        public IActionResult RegistroLibro()
        {
            return View();
        }
    }
}
