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
    public class OrdersController : Controller
    {
        public ICustomerRepository CustomerRepo { get; }
        public IStoreRepository StoreRepo { get; }
        public IOrdersRepository Repo { get; }

        private readonly Project0Context _db;


        public OrderImp CurrentOrder { get; }

        public OrdersController(IOrdersRepository ordersRepo, IStoreRepository storeRepo, ICustomerRepository customerRepo, Project0Context db)
        {
            Repo = ordersRepo;
            StoreRepo = storeRepo;
            CustomerRepo = customerRepo;
            _db = db;
        }

        // GET: Orders
        public ActionResult Index()
        {
            TempData.Keep();
            return View();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TempData.Keep();
                if (!TempData.ContainsKey("Current Customer"))
                {
                    return RedirectToAction("Create", "Customer");
                }
                var Order = Repo.GetAllOrdersByCustomer(int.Parse(TempData["Current Customer"].ToString())).ToList();
                var orderModels = new List<OrderModel>();

                for (int i = 0; i < Order.Count; i++)
                {
                    var orderModel = new OrderModel
                    {
                        OrderId = Order[i].OrderID,
                        OrderCost = Order[i].OrderCost,
                        OrderDate = Order[i].OrderDate,
                        OrderCustomerId = Order[i].OrderCustomer,
                        OrderGames = Order[i].GamesInOrder,
                        OrderStoreId = Order[i].StoreId
                    };
                    orderModels.Add(orderModel);
                }

                return View(orderModels);
            }
            catch (InvalidOperationException ex)
            {
                // should log that, and redirect to error page
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: Orders/Create
        public ActionResult Create(OrderModel order)
        {
            TempData.Keep();
            if (TempData.ContainsKey("Current Customer")) //populates the fields'  initial values
            {
                CustomerImp cust = CustomerRepo.GetCustomerById(int.Parse(TempData["Current Customer"].ToString()));
                order.OrderStoreId = StoreRepo.GetStoreByLocation(cust.DefaultStoreId).IDNumber;
                order.OrderDate = DateTime.Now;
                order.OrderCustomerId = int.Parse(TempData["Current Customer"].ToString());
            }
            else
            {
                return RedirectToAction("Create", "Customer");
            }

            if (order.Stores == null)
            {
                var stores = _db.Stores.ToList();
                stores.AddRange(_db.Stores.ToList());
                order.Stores = new List<StoreImp>();

                foreach (var s in stores)
                {
                    var tempStore = new StoreImp
                    {
                        IDNumber = s.StoreId,
                        Location = s.Location,
                        DeluxeInStock = s.DeluxePackageRemaining,
                        //Items = Mapper.Map(s.Inventory.First(i => i.StoreId == order.OrderStoreId)),
                    };
                    order.Stores.Add(tempStore);
                }
            }



            //var OrderItems = _db.OrderGames.ToList();
            //OrderItems.AddRange(_db.OrderGames.Where(o => o.OrderId == order.OrderId).ToList());
            //order.OrderGames = new List<OrderGamesImp>();

            //foreach (var i in OrderItems)
            //{
            //    var tempOrderGames = new OrderGamesImp
            //    {
            //        OrderId = i.OrderId,
            //        GameId = i.GameId,
            //        Price = i.Price,
            //        GameQuantity = i.GameQuantity,
            //    };
            //    order.OrderGames.Add(tempOrderGames);
            //}

            return View(order);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderModel order, ICollection<OrderImp> placeholder)
        {
            try
            {
                TempData.Keep();

                // TODO: Add insert logic here
                var ord = new OrderImp
                {
                    StoreId = order.OrderStoreId,
                    OrderDate = DateTime.Now,
                };
                ord.OrderCost = ord.TotalOrderCost();

                var OrderItems = _db.OrderGames.ToList();
                OrderItems.AddRange(_db.OrderGames.Where(o => o.OrderId == order.OrderId).ToList());
                
                foreach (var i in OrderItems)
                {
                    var tempOrderGames = new OrderGamesImp
                    {
                        OrderId = i.OrderId,
                        GameId = i.GameId,
                        Price = i.Price,
                        GameQuantity = i.GameQuantity,
                    };
                    order.OrderGames.Add(tempOrderGames);
                }

                ord.GamesInOrder = order.OrderGames;
                Repo.AddOrder(ord);


                return RedirectToAction("Index", "Orders");
            }
            catch (InvalidOperationException ex)
            {
                return RedirectToAction("Index", "Orders");
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectStore(StoreModel store)
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

                return RedirectToAction("Details", "Orders");

            }
            catch
            {
                return RedirectToAction("Index", "Orders");
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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

        // POST: Orders/AddGames
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGames(OrderModel Order)
        {
            OrderModel ord = new OrderModel();
            ord = Order;
            ord.NextOrderGame.GameQuantity = Order.NextOrderGame.GameQuantity;
            ord.NextOrderGame.Edition = Order.NextOrderGame.Edition;
            ord.NextOrderGame.Price = Order.NextOrderGame.GetCostOfPurchase();
            ord.NextOrderGame.Game.Name = Order.NextOrderGame.Game.Name;

            ord.OrderGames.Add(ord.NextOrderGame);

            return View("Create", ord);
        }
    }
}