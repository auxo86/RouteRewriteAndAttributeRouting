using Mod02_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mod02_.DAL;
using System.Net;
using System.Data.Entity;

namespace Mod02_.Controllers
{
    public class OperaController : Controller
    {
        private OperaContext context = new OperaContext();

        public ActionResult Index()
        {
            return View(context.Operas.ToList());
        }

        public ActionResult FilterData(int number)
        {
            //LINQ
            var query = (from o in context.Operas
                         orderby o.Year descending
                         select o).Take(number).ToList();

            return View("Index", query);
        }


        //Opera/Details
        //Opera/Details/99
        //Opera/Details?id=99
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (opera.Title.StartsWith("a"))
            {
                ModelState.AddModelError("Title", "不可以a字元開頭");
                return View(opera);
            }
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opera);
        }

        public string CheckName(string Composer)
        {
            if (Composer == "tony")
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Opera o = context.Operas.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }
        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();

            return View(o);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            Opera o = context.Operas.Find(id);
            context.Operas.Remove(o);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete2(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            context.Operas.Remove(o);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("opera/title/{title}")]
        public ActionResult DetailsByTitle(string title)
        {
            Opera opera =
                context.Operas.FirstOrDefault<Opera>(
                    o => o.Title == title);

            if (opera == null)
            {
                return HttpNotFound();
            }

            return View("Details", opera);
        }


    }
}