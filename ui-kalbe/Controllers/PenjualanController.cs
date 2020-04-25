using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ui_kalbe.Models;

namespace ui_kalbe.Controllers
{
    public class PenjualanController : Controller
    {
        // GET: Penjualan
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                var a = (from b in dbModel.Penjualans
                         join c in dbModel.Customers on b.intCustomerID equals c.intCustomerID
                         select new JoinSales
                         {
                             id = b.intSalesOrderID,
                             qty = b.intQty,
                             customerName = c.txtCustomerName
                         }).ToList();

                return View(a.ToList());
            }
        }

        // GET: Penjualan/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.Where(x => x.intCustomerID == id).FirstOrDefault());
            }
        }

        // GET: Penjualan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Penjualan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Penjualan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Penjualan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Penjualan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Penjualan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
