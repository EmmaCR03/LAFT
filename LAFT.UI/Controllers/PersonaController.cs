using LAFT.Abstracciones.AccessoADatos.Interfaces.BitacoraEventos.Bitacora;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.Editar;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.ObtenerPorID;
using LAFT.Abstracciones.LN.Interfaces.ActividadesFinancieras.Listar;
using LAFT.Abstracciones.LN.Interfaces.ActividadesPersona.Listar;
using LAFT.Abstracciones.LN.Interfaces.BitacoraEventos.Registrar;
using LAFT.Abstracciones.LN.Interfaces.General;
using LAFT.Abstracciones.LN.Interfaces.Persona;
using LAFT.Abstracciones.LN.Interfaces.Persona.CountPersonas;
using LAFT.Abstracciones.LN.Interfaces.Persona.Editar;
using LAFT.Abstracciones.LN.Interfaces.Persona.ObtenerPorId;
using LAFT.Abstracciones.LN.Interfaces.Persona.Registrar;
using LAFT.Abstracciones.Modelos.ArchivosAnalisis;
using LAFT.Abstracciones.Modelos.BitacoraEventos;
using LAFT.Abstracciones.Modelos.Persona;
using LAFT.Abstracciones.ModelosDeBaseDeDatos.BitacoraEventos;
using LAFT.AccesoADatos;
using LAFT.AccesoADatos.BitacoraEventos.Registrar;
using LAFT.AccesoADatos.Persona.Registrar;
using LAFT.LN.ActividadesFinancieras.Listar;
using LAFT.LN.ActividadesPersona.Listar;
using LAFT.LN.BitacoraEventos.Registrar;
using LAFT.LN.General;
using LAFT.LN.Persona.CountPersonas;
using LAFT.LN.Persona.Editar;
using LAFT.LN.Persona.Listar;
using LAFT.LN.Persona.ObtenerPorId;
using LAFT.LN.Persona.Registrar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

public class PersonaController : Controller
{
    IFecha _fecha;
    IListarPersonaLN _listarPersona;
    IRegistrarPersonaLN _registrarPersona;
    IObtenerPersonaPorIdLN _obtenerPorIdLN;
    IEditarPersonaLN _editarPersonaLN;
    IRegistrarBitacoraEventosLN _bitacoraEventosLN;
    IRegistrarServiceLN _registrarServiceLN;
    Contexto _contexto;
    IListarActividadesFinancierasLN _ListarActividadesFinancierasLN;
    IListarActividadesPersonaLN _ListarActividadesPersonaLN;
    public PersonaController()
    {
        _listarPersona = new ListarPersonaLN();
        _registrarPersona = new RegistrarPersonaLN();
        _obtenerPorIdLN = new ObtenerPersonaPorIdLN();
        _editarPersonaLN = new EditarPersonaLN();
        _contexto = new Contexto();
        _registrarServiceLN = new RegistrarServiceLN();
        _ListarActividadesFinancierasLN = new ListarActividadesFinancierasLN();
        _ListarActividadesPersonaLN = new ListarActividadesPersonaLN();

    }

    // GET: Persona
    [Authorize(Roles = "Administrador, Analista")]

    public ActionResult IndexPersona()
    {
        ViewBag.Title = "La Persona";
        var laListaDePersona = _listarPersona.Listar();
        return View(laListaDePersona);
    }
    [Authorize(Roles = "Administrador, Analista")]

    public ActionResult Details(int id)
    {
        PersonaDTO persona = _obtenerPorIdLN.Obtener(id);
        return View(persona);
    }
    // GET: Persona/Create
    public ActionResult Create()
    {
        return View();
    }
    [Authorize(Roles = "Administrador, Analista")]

    // POST: Persona/Create
    [HttpPost]
    public async Task<ActionResult> Create(PersonaDTO modeloDelInventario)
    {
        try
        {
            modeloDelInventario.Estado = true;
            string folderName = "NuevaCarpeta";
            string folderPath = Path.Combine(Server.MapPath("~/Uploads"), folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            await _registrarPersona.Guardar(modeloDelInventario, folderPath);

            return RedirectToAction("IndexPersona");
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Error al guardar los datos: " + ex.Message;
            return View(modeloDelInventario);
        }
    }
    [Authorize(Roles = "Administrador, Analista")]

    // GET: Persona/Edit/5
    public ActionResult Edit(int idPersona)
    {
        var laPersona = _obtenerPorIdLN.Obtener(idPersona);
        return View(laPersona);
    }
    [Authorize(Roles = "Administrador, Analista")]

    // POST: Persona/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(PersonaDTO laPersona)
    {
        try
        {
            int cantidadDeDatosActualizados = await _editarPersonaLN.Actualizar(laPersona);
            if (cantidadDeDatosActualizados == 0)
            {
                ViewBag.mensaje = "Ocurrió un error inesperado, favor intente nuevamente.";
                return View(laPersona);
            }



            return RedirectToAction("IndexPersona");
        }
        catch (Exception ex)
        {
            ViewBag.mensaje = "Ocurrió un error inesperado, favor intente nuevamente.";
            return View(laPersona);
        }
    }
    [Authorize(Roles = "Administrador, Analista")]

    // POST: Persona/ToggleEstado
    [HttpPost]
    public ActionResult ToggleEstado(int IdPersona, bool Estado)
    {
        var persona = _contexto.PersonaTabla.FirstOrDefault(p => p.IdPersona == IdPersona);
        if (persona != null)
        {
            persona.Estado = Estado;
            _contexto.SaveChanges();
        }
        return RedirectToAction("IndexPersona");
    }
    private void CargarActividadesFinancieras(int idPersona)
    {
        var actividadesFinancieras = _ListarActividadesFinancierasLN.ListarActividad()
            .Where(a => a.Estado == true)
            .ToList();

        var actividadesPersona = _ListarActividadesPersonaLN.Listar(idPersona)
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





