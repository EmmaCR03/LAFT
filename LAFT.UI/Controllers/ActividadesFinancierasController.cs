using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Editar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Listar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ActividadesFinancieras;
using LAFT.AccesoADatos;
using LAFT.LN.ActividadesFinancieras.Editar;
using LAFT.LN.ActividadesFinancieras.Listar;
using LAFT.LN.ActividadesFinancieras.ObtenerPorId;
using LAFT.LN.ActividadesFinancieras.Registrar;
using LAFT.LN.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LAFT.UI.Controllers
{
    public class ActividadesFinancierasController : Controller
    {
        IFecha _fecha;
        IListarActividadesFinancierasLN _listarActividadesFinancieras;
        IRegistrarActividadesFinancierasLN _registrarActividadesFinancieras;
        IObtenerPorIdLN _obtenerPorIdLN;
        IEditarActividadesFinancierasLN _editarActividadesFinancierasLN;
        Contexto _contexto;


        public ActividadesFinancierasController()
        {
            _fecha = new Fecha();
            _listarActividadesFinancieras = new ListarActividadesFinancierasLN();
            _registrarActividadesFinancieras = new RegistrarActividadesFinancierasLN();
            _obtenerPorIdLN = new ObtenerPorIdLN();
            _editarActividadesFinancierasLN = new EditarActividadesFinancierasLN();
            _contexto = new Contexto();
        }
        // GET: ActividadesFinancieras
        [Authorize(Roles = "Administrador")]

        public ActionResult IndexActividadesFinancieras()
        {
            ViewBag.Title = "Actividad Financiera";
            List<ActividadesFinancierasDTO> laListaDeActividadesF = _listarActividadesFinancieras.ListarActividad();
            return View(laListaDeActividadesF);
        }
        [Authorize(Roles = "Administrador")]


        // GET: ActividadesFinancieras/Details/5
        public ActionResult Details(int id)
        {

            return View(/*ActividadFinanciera*/);
        }
        [Authorize(Roles = "Administrador")]


        // GET: ActividadesFinancieras/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]

        // POST: ActividadesFinancieras/Create
        [HttpPost]
        public async Task<ActionResult> Create(ActividadesFinancierasDTO modeloDelInventario)
        {
            try
            {
                modeloDelInventario.Estado = true;
                string folderName = "NuevaCarpeta";
                string folderPath = Path.Combine(Server.MapPath("~/Uploads"), folderName);
                int cantidadDeDatosGuardados = await _registrarActividadesFinancieras.Guardar(modeloDelInventario, folderPath);
                return RedirectToAction("IndexActividadesFinancieras");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador")]

        [HttpPost]
        public ActionResult ToggleEstado(int IdActividadFinanciera, bool Estado)
        {
            var persona = _contexto.ActividadesFinancierasTabla.FirstOrDefault(p => p.IdActividadFinanciera == IdActividadFinanciera);
            if (persona != null)
            {
                persona.Estado = Estado;
                _contexto.SaveChanges();
            }
            return RedirectToAction("IndexActividadesFinancieras");
        }
        [Authorize(Roles = "Administrador")]

        // GET: ActividadesFinancieras/Edit/5
        public ActionResult Edit(int IdActividadFinanciera)
        {
            ActividadesFinancierasDTO laActividadF = _obtenerPorIdLN.Obtener(IdActividadFinanciera);
            return View(laActividadF);
        }
        [Authorize(Roles = "Administrador")]

        // POST: ActividadesFinancieras/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ActividadesFinancierasDTO laActividadF)
        {
            try
            {
                ViewBag.cantidadDeDatosActualizados = 1;
                // TODO: Add update logic here
                int cantidadDeDatosActualizados = await _editarActividadesFinancierasLN.Actualizar(laActividadF);
                if (cantidadDeDatosActualizados == 0)
                {
                    ViewBag.cantidadDeDatosActualizados = cantidadDeDatosActualizados;
                    ViewBag.mensaje = "Ocurrio un error inesperado, favor intente nuevamente.";
                    return View(laActividadF);
                }
                return RedirectToAction("IndexActividadesFinancieras");
            }
            catch
            {
                ViewBag.cantidadDeDatosActualizados = 0;
                ViewBag.mensaje = "Ocurrio un error inesperado, favor intente nuevamente.";
                return View(laActividadF);
            }
        }
        [Authorize(Roles = "Administrador")]

        // GET: ActividadesFinancieras/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActividadesFinancieras/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]

        public ActionResult ToggleEstadoUno(int IdActividadFinanciera, bool Estado)
        {
            var ActividadFinanciera = _contexto.ActividadesFinancierasTabla.FirstOrDefault(p => p.IdActividadFinanciera == IdActividadFinanciera);
            if (ActividadFinanciera != null)
            {
                ActividadFinanciera.Estado = Estado;
                _contexto.SaveChanges();
            }
            return RedirectToAction("IndexActividadesFinancieras");
        }
    }
}
    