using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Datos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class TblPrestamoController : Controller
    {
        ConsultasBd Cbd = new ConsultasBd();
        
        public IActionResult LeerPrestamo()
        {
            var respuesta = Cbd.LeerPrestamo();
            return View(respuesta);
            
        }

        public IActionResult InsertarPrestamo()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertarPrestamo(PrestamoModel oPrestamo)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = Cbd.GuardarPrestamo(oPrestamo);

            if (respuesta)
                return RedirectToAction("LeerPrestamo");
            else
                return View();
        }
    }
}
