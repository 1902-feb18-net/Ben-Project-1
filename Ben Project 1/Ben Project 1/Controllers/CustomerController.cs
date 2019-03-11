﻿using System;
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
    public class CustomerController : Controller
    {
        public ICustomerRepository Repo { get; }
        public IStoreRepository StoreRepo { get; }

        public CustomerImp CurrentCustomer { get; }

        private readonly Project0Context _db;

        public CustomerController(ICustomerRepository customerRepo, IStoreRepository storeRepo, Project0Context db)
        {
            Repo = customerRepo;
            StoreRepo = storeRepo;
            _db = db;
        }

        // GET: Customer
        public ActionResult Index()
        {
            TempData.Clear();
            var customer = new CustomerModel

            {
                Stores = StoreRepo.GetStores().ToList()
            };

            return View("Create", customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {

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
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DefaultStoreId = StoreRepo.GetStoreByLocation(customer.DefaultStoreId).IDNumber
                };

                TempData["Current Customer"] = cust.Id;

                string name = Repo.GetCustomerById(cust.Id).FirstName + " " + Repo.GetCustomerById(cust.Id).LastName;

                TempData["Customer Name"] = name;

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

                string name = Repo.GetCustomerById(cust.Id).FirstName + " " + Repo.GetCustomerById(cust.Id).LastName;

                TempData["Customer Name"] = name;
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