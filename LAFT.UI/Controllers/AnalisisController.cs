using LAFT.Abstracciones.LN.Interfaces.Analisis.Listar;
using LAFT.Abstracciones.LN.Interfaces.Analisis.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.Analisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.ArchivosAnalisis.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.Modelos.Analisis;
using LAFT.LN.Analisis.Listar;
using LAFT.LN.Analisis.Registrar;
using LAFT.LN.ArchivosAnalisis.Registrar;
using LAFT.LN.General;
using LAFT.LN.ModuloAnalisis.ObtenerPorId;
using LAFT.LN.ModuloAnalisis.Registrar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LAFT.UI.Controllers
{
    public class AnalisisController : Controller
    {
        IAnalisisLN _analizarLN;
        IRegistrarAnalisisLN _registrarAnalisis;
        IListarAnalisisLN _listarPersonas;
        IObtenerPorIdAnalisisPersonaLN _Obtener;
        IRegistrarArchivosAnalisisLN _registrarArchivos;



        public AnalisisController()
        {
            _analizarLN = new AnalizarLN();
            _registrarAnalisis = new RegistrarAnalisisLN();
            _listarPersonas = new ListarAnalisisLN();
            _Obtener = new ObtenerPorIdAnalisisPersonaLN();
            _registrarArchivos = new RegistrarArchivosAnalisisLN();
        }

        public ActionResult ListarPorId(int idPersona)
        {
            try
            {
                List<AnalisisDTO> laListaDeAnalisis = _Obtener.Detalle(idPersona);
                return View(laListaDeAnalisis);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AnalisisPersona", "ListarPorId"));
            }
        }

        public ActionResult Analizar(int idPersona)
        {
            try
            {
                _registrarAnalisis.Registrar(idPersona);
                return RedirectToAction("ListarPorId", "Analisis");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AnalisisPersona", "Analizar"));
            }
        }

        public ActionResult Listar()
        {
            ViewBag.Title = "Los Análisis de Personas";
            List<PersonaAnalizadaDto> laListaDeAnalisis = _listarPersonas.Listar();
            return View(laListaDeAnalisis);

        }
        // GET: AnalisisPersona
        public ActionResult Index()
        {
            return RedirectToAction("Index");
        }

        // GET: AnalisisPersona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnalisisPersona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnalisisPersona/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AnalisisPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnalisisPersona/Edit/5
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

        // GET: AnalisisPersona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnalisisPersona/Delete/5
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
