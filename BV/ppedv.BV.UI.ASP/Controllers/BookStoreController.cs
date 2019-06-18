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
            repository = new EFRepository(new EFContext(connectionString));
            core = new Core(repository);
        }
        private readonly Core core;
        private readonly IRepository repository;

        // GET: BookStore
        public ActionResult Index()
        {
            return View(repository.GetAll<BookStore>());
        }

        // GET: BookStore/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.GetByID<BookStore>(id));
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
                repository.Add(newBookStore);
                repository.Save();

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
            return View(repository.GetByID<BookStore>(id));
        }

        // POST: BookStore/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookStore editedBookStore)
        {
            try
            {
                repository.Update(editedBookStore);
                repository.Save();

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
            return View(repository.GetByID<BookStore>(id));
        }

        // POST: BookStore/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookStore _NOTused_)
        {
            try
            {
                var bookToDelete = repository.GetByID<BookStore>(id);
                repository.Delete(bookToDelete);
                repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
