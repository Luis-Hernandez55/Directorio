using Noviembrex.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembrex.Web.Controllers
{
    public class GuaymasController : Controller
    {
        // GET: Guaymas
        public ActionResult Index()
        {
            List<Guaymas> guaymass = Guaymas.GetAll();
            return View(guaymass);
        }

        public ActionResult Registro(int id)
        {
            Guaymas guaymas = Guaymas.GetById(id);
            return View(guaymas);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            Guaymas.Guardar(id, nombre, apellido, telefono, direccion);
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id)
        {
            Guaymas.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}