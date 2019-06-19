using ppedv.BV.Data.EF;
using ppedv.BV.Domain;
using ppedv.BV.Domain.Interfaces;
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
            core = new Core(new EFUnitOfWork(new EFContext(connectionString)));
        }
        private readonly Core core;

        // GET: BookStore
        public ActionResult Index()
        {
            return View(core.UnitOfWork.BookStoreRepository.GetAll());
        }

        // GET: BookStore/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UnitOfWork.BookStoreRepository.GetByID(id));
        }

        // GET: BookStore/Create
        public ActionResult Create()
        {
            return View(new BookStore { Address = "Neuegasse 22" });
        }

        // POST: BookStore/Create
        [HttpPost]
        public ActionResult Create(BookStore newBookStore) //(FormCollection collection)
        {
            try
            {
                core.UnitOfWork.BookStoreRepository.Add(newBookStore);
                core.UnitOfWork.Save();

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
            return View(core.UnitOfWork.BookStoreRepository.GetByID(id));
        }

        // POST: BookStore/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookStore editedBookStore)
        {
            try
            {
                core.UnitOfWork.BookStoreRepository.Update(editedBookStore);
                core.UnitOfWork.Save();

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
            return View(core.UnitOfWork.BookStoreRepository.GetByID(id));
        }

        // POST: BookStore/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookStore _NOTused_)
        {
            try
            {
                var bookToDelete = core.UnitOfWork.BookStoreRepository.GetByID(id);
                core.UnitOfWork.BookStoreRepository.Delete(bookToDelete);
                core.UnitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
