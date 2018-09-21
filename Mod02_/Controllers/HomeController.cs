using Mod02_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod02_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            ViewBag.id = f["id"];
            ViewBag.name = f["name"];
            return View();

        }

        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2(Member m)
        {
            ViewBag.id = m.id;
            ViewBag.name = m.name;
            return View();

        }

        public ActionResult Index3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index3(Member m)
        {
            ViewBag.id = m.id;
            ViewBag.name = m.name;
            ViewBag.phone = string.Join("_", m.phone);
            return View();

        }
    }
}