using Noviembrex.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembrex.Web.Controllers
{
    public class EmpalmeController : Controller
    {
        // GET: Empalme
        public ActionResult Index()
        {
            List<Empalme> empalmes = Empalme.GetAll();
            return View(empalmes);
        }

        public ActionResult Registro(int id)
        {
            Empalme empalme = Empalme.GetById(id);
            return View(empalme);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            Empalme.Guardar(id, nombre, apellido, telefono, direccion);
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id)
        {
            Empalme.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}