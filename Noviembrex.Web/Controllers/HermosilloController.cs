using Noviembrex.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembrex.Web.Controllers
{
    public class HermosilloController : Controller
    {
        // GET: Hermosillo
        public ActionResult Index()
        {
            List<Hermosillo> hermosillos = Hermosillo.GetAll();
            return View(hermosillos);
        }

        public ActionResult Registro(int id)
        {
            Hermosillo hermosillo = Hermosillo.GetById(id);
            return View(hermosillo);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            Hermosillo.Guardar(id, nombre, apellido, telefono, direccion);
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id)
        {
            Hermosillo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}