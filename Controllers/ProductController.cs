using NimapInfotechProject.Models;
using NimapInfotechProject.SqlContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapInfotechProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.CategorieDropDown = CategorieDropDown();
            return View();
        }
        public ActionResult Partial_View()
        {
            ViewBag.CategorieDropDown = CategorieDropDown();
            return View();
        }
        public ActionResult Report()
        {
            using (DbNimapInfotechTaksEntities Db = new DbNimapInfotechTaksEntities())
            {
                return View(Db.SpProduct().ToList());
            }
        }
        public List<SelectListItem> CategorieDropDown()
        {

            var _selectList = new List<SelectListItem>();
            _selectList.Add(new SelectListItem { Value = "0", Text = "--Select--" });
            var Categorie = (dynamic)null;

            using (DbNimapInfotechTaksEntities _db = new DbNimapInfotechTaksEntities())
            {
                Categorie = (from x in _db.MCategories
                             select new
                             {
                                 x.CategoryId,
                                 x.CategoryName
                             });

                foreach (var item in Categorie)
                {
                    _selectList.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName.ToString() });
                }
            }
            return _selectList;
        }

        public ActionResult SaveOrUpdate(ProductModel model)
        {
            try
            {
                using (DbNimapInfotechTaksEntities _db = new DbNimapInfotechTaksEntities())
                {
                    if (model.ProductId == 0)
                    {
                        MProduct Product = new MProduct()
                        {
                            ProductName = model.ProductName,
                            CategoryId = model.CategoryId,
                        };
                        _db.Entry(Product).State = EntityState.Added;
                    }
                    else
                    {
                        MProduct Product = new MProduct()
                        {
                            ProductId = model.ProductId,
                            ProductName = model.ProductName,
                            CategoryId = model.CategoryId,
                        };
                        _db.Entry(Product).State = EntityState.Modified;
                    }
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteData(int id)
        {

            using (DbNimapInfotechTaksEntities _db = new DbNimapInfotechTaksEntities())
            {
                try
                {
                    MProduct Product = new MProduct()
                    {
                        ProductId = id
                    };

                    _db.Entry(Product).State = EntityState.Deleted;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult EditData(int id)
        {
            ViewBag.CategorieDropDown = CategorieDropDown();

            ProductModel model;
            using (DbNimapInfotechTaksEntities _db = new DbNimapInfotechTaksEntities())
            {
                var data = new MProduct();
                data = _db.MProducts.Where(x => x.ProductId == id).FirstOrDefault();

                model = new ProductModel()
                {
                    ProductId = data.ProductId,
                    ProductName = data.ProductName,
                    CategoryId = data.CategoryId,
                };
                return PartialView("Index", model);
            }
        }
    }
}