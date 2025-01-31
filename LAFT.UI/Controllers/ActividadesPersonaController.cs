using LAFT.Abstracciones.LN.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Listar;
using LAFT.LN.General;
using LAFT.LN.ActividadesPersona.Listar;
using LAFT.Abstracciones.Modelos.ActividadesPersona;
using System.IO;
using System.Threading.Tasks;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Registrar;
using LAFT.LN.ActividadesPersona.Registrar;
using LAFT.LN.ActividadesPersona.ObtenerPorId;
using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.Eliminar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Eliminar;
using LAFT.LN.ActividadesPersona.Eliminar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Listar;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.LN.ActividadesFinancieras.Listar;
using LAFT.AccesoADatos.Persona.ObtenerPorId;
using LAFT.LN.Persona.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.ObtenerPorId;
using LAFT.Abstracciones.AccessoADatos.Interfaces.ActividadesPersona.ObtenerPorId;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.ObtenerPorID;
using LAFT.Abstracciones.LN.Interfaces.Persona.ObtenerPorId;

namespace LAFT.UI.Controllers
{
    public class ActividadesPersonaController : Controller
    {
        IFecha _fecha;
        IListarActividadesPersonaLN _listarActividadesPersona;
        IRegistrarActividadesPersonaLN _registrarActividadesPersona;
        IEliminarActividadesPersonaLN _eliminarActividadesPersonas;
        IListarActividadesFinancierasLN _listarActividadesFinancieras;
        IObtenerPersonaPorIdLN _obtenerPersonaPorId;
        public ActividadesPersonaController()
        {
            _fecha = new Fecha();
            _listarActividadesPersona = new ListarActividadesPersonaLN();
            _registrarActividadesPersona = new RegistrarActividadesPersonaLN();
            _eliminarActividadesPersonas = new EliminarActividadesPersonaLN();
            _listarActividadesFinancieras = new ListarActividadesFinancierasLN();
            _obtenerPersonaPorId = new ObtenerPersonaPorIdLN();

        }
        // GET: ActividadesPersona
        [Authorize(Roles = "Administrador, Analista")]

        public ActionResult IndexActividadesPersona(int id)
        {
            ViewBag.Title = "La Actividad Persona";
            ViewBag.IdPersona = id; // Pasar el IdPersona a la vista

            // Llamar al método Listar pasando el id de la persona
            List<ActividadesPersonaDTO> laListaDeActividadPersona = _listarActividadesPersona.Listar(id);


            // Devolver la vista con la lista de ActividadesPersona
            return View(laListaDeActividadPersona);
        }


        [Authorize(Roles = "Administrador, Analista")]

        // GET: ActividadesPersona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActividadesPersona/Create
        public ActionResult Create(int id)
        {
            // Obtener las actividades financieras para llenar el DropDownList
            List<ActividadesFinancierasDTO> actividadesFinancieras = _listarActividadesFinancieras.ListarActividad();

            // Crear un SelectList para el ComboBox en la vista
            ViewBag.ActividadesFinancieras = new SelectList(actividadesFinancieras, "IdActividadFinanciera", "NombreActividadFinanciera");

            // Pasar el idPersona a la vista
            var modelo = new ActividadesPersonaDTO { IdPersona = id };
            return View(modelo);
        }
        [Authorize(Roles = "Administrador, Analista")]


        [HttpPost]
        public async Task<ActionResult> Create(ActividadesPersonaDTO modeloDeActividadesPersona)
        {
            try
            {
                if (modeloDeActividadesPersona.IdPersona == 0)
                {
                    ModelState.AddModelError("", "IdPersona es requerido.");
                    return View(modeloDeActividadesPersona);
                }

                string folderName = "NuevaCarpeta";
                string folderPath = Path.Combine(Server.MapPath("~/Uploads"), folderName);

                // Registrar la actividad
                int cantidadDeDatosGuardados = await _registrarActividadesPersona.Guardar(modeloDeActividadesPersona, folderPath);

                return RedirectToAction("IndexActividadesPersona", new { id = modeloDeActividadesPersona.IdPersona });
            }
            catch
            {
                return View(modeloDeActividadesPersona);
            }
        }

        [Authorize(Roles = "Administrador, Analista")]

        // GET: ActividadesPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActividadesPersona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Analista")]

        // GET: ActividadesPersona/Delete/5
        public ActionResult Delete(int IdActividadPersona)
        {
            return View();
        }

        // POST: Cursos/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int IdActividadPersona, ActividadesPersonaDTO laActividad)
        {
            try
            {
                // TODO: Add delete logic here
                int cantidadDeElementosEliminados = await _eliminarActividadesPersonas.Eliminar(IdActividadPersona);

                return RedirectToAction("IndexActividadesPersona");
            }
            catch
            {
                return View();
            }
        }
        private void CargarActividadesFinancieras(int idPersona)
        {
            var actividadesFinancieras = _listarActividadesFinancieras.ListarActividad()
                .Where(a => a.Estado == true)
                .ToList();

            var actividadesPersona = _listarActividadesPersona.Listar(idPersona)
                .Where(a => a.Estado == true)
                .ToList();

            var actividadesUnicas = actividadesFinancieras
                .Where(fin => !actividadesPersona.Any(per => per.IdActividadFinanciera == fin.IdActividadFinanciera))
                .ToList();


            if (!actividadesUnicas.Any())
            {
                ViewBag.ActividadesFinancieras = "No hay actividades disponibles";
            }
            else
            {
                ViewBag.ActividadesFinancieras = actividadesUnicas;
            }
        }

    }
}