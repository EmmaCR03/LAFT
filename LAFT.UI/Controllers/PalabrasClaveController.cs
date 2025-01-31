using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Editar;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Listar;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.PalabrasClave.Registrar;
using LAFT.Abstracciones.Modelos.PalabrasClave;
using LAFT.AccesoADatos;
using LAFT.LN.PalabrasClave.Editar;
using LAFT.LN.PalabrasClave.Listar;
using LAFT.LN.PalabrasClave.ObtenerPorId;
using LAFT.LN.PalabrasClave.Registrar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LAFT.UI.Controllers
{
    public class PalabrasClaveController : Controller
    {
         IListarPalabrasClaveLN _listarPalabraClave;
        IRegistrarPalabraClaveLN _registrarPalabraClave;
         IEditarPalabraClaveLN _editarPalabraClaveLN;
         IObtenerPorIdLN _obtenerPorIdLN;
        Contexto _contexto;

        public PalabrasClaveController()
        {
            _listarPalabraClave = new ListarPalabrasClaveLN();
            _registrarPalabraClave = new RegistrarPalabraClaveLN();
            _editarPalabraClaveLN = new EditarPalabraClaveLN();
            _obtenerPorIdLN = new ObtenerPorIdLN();
        }

        // GET: PalabrasClave
        [Authorize(Roles = "Administrador, Analista")]

        public ActionResult IndexPalabrasClave()
        {
            ViewBag.Title = "Lista de Palabras Clave";
            List<PalabrasClaveDTO> palabrasClave = _listarPalabraClave.Listar();
            return View(palabrasClave);
        }
        [Authorize(Roles = "Administrador, Analista")]


        // GET: PalabrasClave/Details/5
        public ActionResult Details(int id)
        {

            return View(/*PalabrasClave*/);
        }
        [Authorize(Roles = "Administrador, Analista")]

        // GET: PalabrasClave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PalabrasClave/Create
        [HttpPost]
        public async Task<ActionResult> Create(PalabrasClaveDTO modeloDelaPalabraClave)
        {
            try
            {
                modeloDelaPalabraClave.Estado = true;
                string folderName = "NuevaCarpeta";
                string folderPath = Path.Combine(Server.MapPath("~/Uploads"), folderName);

                int cantidadDeDatosGuardados = await _registrarPalabraClave.Guardar(modeloDelaPalabraClave, folderPath);

                if (cantidadDeDatosGuardados > 0)
                {
                    return RedirectToAction("IndexPalabrasClave");
                }

                ViewBag.Error = "Ocurrió un problema al registrar la palabra clave.";
                return View(modeloDelaPalabraClave);
            }
            catch (Exception ex)
            {
                // Registrar evento de error en bitácora
                ViewBag.Error = "Error: " + ex.Message;
                return View(modeloDelaPalabraClave);
            }
        }
        [Authorize(Roles = "Administrador, Analista")]

        // GET: PalabrasClave/Edit/5
        public ActionResult Edit(int IdPalabra)
        {
            PalabrasClaveDTO laPalabra = _obtenerPorIdLN.Obtener(IdPalabra);
            return View(laPalabra);
        }


        // POST: Persona/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PalabrasClaveDTO laPalabra)
        {
            try
            {
                int cantidadDeDatosActualizados = await _editarPalabraClaveLN.Actualizar(laPalabra);
                if (cantidadDeDatosActualizados == 0)
                {
                    ViewBag.cantidadDeDatosActualizados = cantidadDeDatosActualizados;
                    ViewBag.mensaje = "Ocurrió un error inesperado, favor intente nuevamente.";
                    return View(laPalabra);
                }
                return RedirectToAction("IndexPalabrasClave");
            }
            catch
            {
                ViewBag.cantidadDeDatosActualizados = 0;
                ViewBag.mensaje = "Ocurrió un error inesperado, favor intente nuevamente.";
                return View(laPalabra);
            }
        }
        [Authorize(Roles = "Administrador, Analista")]

        // GET: PalabrasClave/Delete/5
        public ActionResult Delete(int id)
        {
            PalabrasClaveDTO palabra = _obtenerPorIdLN.Obtener(id);
            if (palabra == null)
            {
                return HttpNotFound();
            }
            return View(palabra);
        }

        // POST: PalabrasClave/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Lógica de eliminación (por implementar)
                return RedirectToAction("IndexPalabrasClave");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Analista")]

        [HttpPost]
        public ActionResult ToggleEstadoDos(int IdPalabra, bool Estado)
        {
            var palabraClave = _contexto.PalabrasClaveTabla.FirstOrDefault(p => p.IdPalabra == IdPalabra);
            if (palabraClave != null)
            {
                palabraClave.Estado = Estado;
                _contexto.SaveChanges();
            }
            return RedirectToAction("IndexPalabrasClave");
        }
    }
}
