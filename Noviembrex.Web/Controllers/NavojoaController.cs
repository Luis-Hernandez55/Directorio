using Noviembrex.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembrex.Web.Controllers
{
    public class NavojoaController : Controller
    {
        // GET: Navojoa
        public ActionResult Index()
        {
            List<Navojoa> navojoas = Navojoa.GetAll();
            return View(navojoas);
        }

        public ActionResult Registro(int id)
        {
            Navojoa navojoa = Navojoa.GetById(id);
            return View(navojoa);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string telefono, string direccion)
        {
            Navojoa.Guardar(id, nombre, apellido, telefono, direccion);
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id)
        {
            Navojoa.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}