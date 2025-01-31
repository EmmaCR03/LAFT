using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Listar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.LN.BitacoraEventos;
using LAFT.LN.BitacoraEventos.Registrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LAFT.UI.Controllers
{
    public class BitacoraEventosController : Controller
    {
        IListarBitacoraEventosLN _listarEventos;
        IRegistrarBitacoraEventosLN _registrarBitacoraEventosLN;
        public BitacoraEventosController()
        {
            _listarEventos = new ListarBitacoraEventosLN();
            _registrarBitacoraEventosLN = new RegistrarBitacoraEventosLN();
        }
        // GET: BitacoraEventos
        [Authorize(Roles = "Administrador")]

        public ActionResult IndexBitacoraEventos()
        {
            ViewBag.Title = "Bitacora";
            List<BitacoraEventosDTO> bitacora = _listarEventos.ListarBitacora();
            return View(bitacora);
        }
        [Authorize(Roles = "Administrador")]

        // GET: BitacoraEventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        [Authorize(Roles = "Administrador")]

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


        // GET: BitacoraEventos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BitacoraEventos/Edit/5
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

        // GET: BitacoraEventos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BitacoraEventos/Delete/5
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
