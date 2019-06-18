using ppedv.BV.Data.EF;
using ppedv.BV.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.BV.UI.ASP.Controllers
{
    public class BookStoreController : Controller
    {
        private const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BV_Produktiv;Trusted_Connection=true;AttachDbFilename=C:\temp\BV.mdf";
        public BookStoreController()
        {
            core = new Core(new EFRepository(new EFContext(connectionString)));
        }
        private readonly Core core;

        // GET: BookStore
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookStore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookStore/Create
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

        // GET: BookStore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookStore/Edit/5
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

        // GET: BookStore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookStore/Delete/5
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
