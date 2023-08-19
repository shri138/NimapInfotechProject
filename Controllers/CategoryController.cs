using NimapInfotechProject.Models;
using NimapInfotechProject.SqlContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapInfotechProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_View()
        {
            return View();
        }
        public ActionResult SaveRecord(CategoryModel model)
        {
            using (DbNimapInfotechTaksEntities Db = new DbNimapInfotechTaksEntities())
            {
                MCategory category = new MCategory()
                {
                    CategoryName = model.CategoryName,
                };
                Db.Entry(category).State = EntityState.Added;
                Db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}