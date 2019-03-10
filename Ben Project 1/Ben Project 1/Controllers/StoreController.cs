using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ben_Project_1.Models;
using DBContext.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_1.BLL.Library.Implementation;
using Project_1.BLL.Library.IRepos;

namespace Ben_Project_1.Controllers
{
    public class StoreController : Controller
    {
        public ICustomerRepository CustomerRepo { get; }
        public IStoreRepository Repo { get; }
        public IOrderGamesRepository OrdersRepo { get; }

        private readonly Project0Context _db;

        public StoreController(ICustomerRepository customerRepo, IStoreRepository storeRepo, IOrderGamesRepository ordersRepo)
        {
            CustomerRepo = customerRepo;
            Repo = storeRepo;
            OrdersRepo = ordersRepo;
        }

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Store/Select
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Select(StoreModel store)
        {
            try
            {
                // TODO: Add insert logic here
                var st = new StoreImp
                {
                    IDNumber = store.StoreId,
                    Location = store.Location
                };

                TempData["Store Selected"] = st.IDNumber;
                TempData.Keep();


                return RedirectToAction("Index", "Orders");
            }
            catch
            {
                return RedirectToAction("Create", "Customer");
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}