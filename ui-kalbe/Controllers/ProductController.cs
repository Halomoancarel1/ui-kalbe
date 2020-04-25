using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ui_kalbe.Models;

namespace ui_kalbe.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Produks.ToList());
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Produks.Where(x => x.intProductID == id).FirstOrDefault());
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Produk product)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    product.dtInserted = DateTime.Now;
                    dbModel.Produks.Add(product);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }   
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Produks.Where(x => x.intProductID == id).FirstOrDefault());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produk product)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(product).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.Where(x => x.intCustomerID == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produk product)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModel = new DbModels())
                {
                    product = dbModel.Produks.Where(x => x.intProductID == id).FirstOrDefault();
                    dbModel.Produks.Remove(product);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
