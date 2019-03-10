using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ben_Project_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_1.BLL.Library.Implementation;
using Project_1.BLL.Library.IRepos;

namespace Ben_Project_1.Controllers
{
    public class CustomerController : Controller
    {
        public ICustomerRepository Repo { get; }
        public IStoreRepository StoreRepo { get; }

        public CustomerImp CurrentCustomer { get; }

        public CustomerController(ICustomerRepository customerRepo, IStoreRepository storeRepo)
        {
            Repo = customerRepo;
            StoreRepo = storeRepo;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            TempData["Current Customer"] = null;
            var customer = new CustomerModel

            {
                Stores = StoreRepo.GetStores().ToList()
            };
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                // TODO: Add insert logic here
                var cust = new CustomerImp
                {
                    //Id = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DefaultStoreId = StoreRepo.GetStoreByLocation(customer.DefaultStoreId).IDNumber
                };

                TempData["Current Customer"] = cust.Id;
                Repo.AddCustomer(cust);


                return RedirectToAction("Index", "Orders");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/LogIn/5
        public ActionResult LogIn(int id)
        {
            return View();
        }

        // POST: Customer/LogIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(CustomerModel customer)
        {
            try
            {
                // TODO: Add insert logic here
                var cust = new CustomerImp
                {
                    Id = Repo.GetCustomerByName(customer.FirstName + " " + customer.LastName).Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    //DefaultStoreId = StoreRepo.GetStoreByLocation(customer.DefaultStoreId).IDNumber
                };

                TempData["Current Customer"] = cust.Id;
                TempData.Keep();


                return RedirectToAction("Index", "Orders");
            }
            catch
            {
                return RedirectToAction("Create", "Customer");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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