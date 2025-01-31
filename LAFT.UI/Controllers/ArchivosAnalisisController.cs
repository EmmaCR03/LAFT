using LAFT.Abstracciones.AccessoADatos.Interfaces.ArchivosAnalisis.Listar;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.Listar;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.LN.ArchivosAnalisis.Listar;
using LAFT.LN.ArchivosAnalisis.ObtenerPorId;
using LAFT.LN.ArchivosAnalisis.Registrar;
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
    public class ArchivosAnalisisController : Controller
    {
        IListarArchivosAnalisisLN _listarArchivos;
        IFecha _fecha;
        IRegistrarArchivosAnalisisLN _registrarArchivos;
        IObtenerArchivosPorIdLN _obtenerId;

        public ArchivosAnalisisController() 
        {
            _listarArchivos = new ListarArchivosAnalisisLN();
            _fecha = new Fecha();
            _registrarArchivos = new RegistrarArchivosAnalisisLN();
            _obtenerId = new ObtenerArchivoPorIdLN();

        }
        // GET: ArchivosAnalisis
        [Authorize(Roles = "Administrador, Analista")]

        public ActionResult IndexArchivosAnalisis()
        {
            ViewBag.Title = "Los Archivos";
            List<ArchivosAnalisisDTO> laListaDeArchivo= _listarArchivos.Listar();
            return View(laListaDeArchivo);
        }

        // GET: ArchivosAnalisis/Details/5
        [Authorize(Roles = "Administrador, Analista")]

        public ActionResult Details(int id)
        {
            ArchivosAnalisisDTO archivo = _obtenerId.Obtener(id);
            return View(archivo);
        }

        // GET: ArchivosAnalisis/Create
        [Authorize(Roles = "Administrador, Analista")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchivosAnalisis/Create
        [HttpPost]
        public async Task<ActionResult> Create(ArchivosAnalisisDTO modeloDelArchivo)
        {
            try
            {
                string folderName = "NuevaCarpeta"; 
                string folderPath = Path.Combine(Server.MapPath("~/Uploads"), folderName);
                // TODO: Add insert logic here
                int cantidadDeDatosGuardados = await _registrarArchivos.Guardar(modeloDelArchivo, folderPath);
                return RedirectToAction("IndexArchivosAnalisis");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Analista")]

        // GET: ArchivosAnalisis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArchivosAnalisis/Edit/5
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

        // GET: ArchivosAnalisis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArchivosAnalisis/Delete/5
        [HttpPost]
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
    }
}
