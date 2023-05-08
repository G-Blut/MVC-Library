using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Datos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class TblLibroController : Controller
    {
        ConsultasBd Cbd = new ConsultasBd();

        public IActionResult InsertarLibro()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertarLibro(LibroModel oLibro)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = Cbd.GuardarLibro(oLibro);

            if (respuesta)
                return RedirectToAction("LeerLibro");
            else
                return View();
        }


        [HttpPost]
        public async Task<IActionResult> ActualizarLibro(LibroModel oLibro)
        {

            var response = Cbd.EditarLibro(oLibro);

            if (response)
            {
                return RedirectToAction("LeerLibro");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditarLibro(int IdRows)
        {
            var oLibro = Cbd.ObtenerLibro(IdRows);
            return View(oLibro);
        }

        public IActionResult LeerLibro()
        {
            var respuesta = Cbd.LeerLibro();
            return View(respuesta);
        }

        public IActionResult EliminarLibro(int IdRows)
        {
            var oLibro = Cbd.ObtenerLibro(IdRows);
            return View(oLibro);

        }

        [HttpPost]
        public IActionResult EliminarUnLibro(int IdRows)
        {
            var respuesta = Cbd.EliminarLibro(IdRows);

            if (respuesta)

                return RedirectToAction("LeerLibro");

            else

                return View();
        }
    }
}
