using Noviembrex.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembrex.Web.Controllers
{
    public class NogalesController : Controller
    {
        // GET: Nogales
        public ActionResult Index()
        {
            List<Nogales> nogaless = Nogales.GetAll();
            return View(nogaless);
        }

        public ActionResult Registro(int id)
        {
            Nogales nogales = Nogales.GetById(id);
            return View(nogales);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            Nogales.Guardar(id, nombre, apellido, telefono, direccion);
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id)
        {
            Nogales.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}