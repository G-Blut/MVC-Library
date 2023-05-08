using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Datos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class TblEstudianteController : Controller
    {
        ConsultasBd Cbd = new ConsultasBd();

        public IActionResult LeerEstudiante()
        {
            var respuesta = Cbd.LectorEstudiante();

            return View(respuesta);
        }

        public IActionResult InsertarEstudiante()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertarEstudiante(EstudianteModel oEstudiante)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = Cbd.Guardar(oEstudiante);

            if (respuesta)
                return RedirectToAction("LeerEstudiante");
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstudiante(EstudianteModel oEstudiante)
        {

            var response = Cbd.Editar(oEstudiante);

            if (response)
            {
                return RedirectToAction("LeerEstudiante");
            }
            else
            {
                return View();
            }

        }

        public IActionResult EditarEstudiante(int IdRows)
        {
            var oEstudiante = Cbd.ObtenerEstudiante(IdRows);
            return View(oEstudiante);
        }

        public IActionResult EliminarEstudiante(int IdRows)
        {
            var oEstudiante = Cbd.ObtenerEstudiante(IdRows);
            return View(oEstudiante);

        }

        [HttpPost]
        public IActionResult EliminarUnEstudiante(int IdRows)
        {
            var respuesta = Cbd.EliminarEstudiante(IdRows);

                if (respuesta)
            
                    return RedirectToAction("LeerEstudiante");
                    
                else
                
                    return View();
        }
    }
}
