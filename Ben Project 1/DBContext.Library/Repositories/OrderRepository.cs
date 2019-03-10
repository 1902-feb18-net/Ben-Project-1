using DBContext.Library;
using Microsoft.EntityFrameworkCore;
using Project_1.BLL.Library.Implementation;
using Project_1.BLL.Library.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_1.DBContext.Library.Repositories
{
    public class OrderRepository : IOrderGamesRepository
    {

        private readonly Project0Context _db;

        public OrderRepository(Project0Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public OrderImp GetOrderByID(int ID)
        {
            //goes through _Data to find order with specified ID
            //returns null if ID doesn't exist
            return Mapper.Map(_db.Orders.First(r => r.OrderId == ID)) ?? throw new ArgumentNullException("ID needs to be valid");
        }
        
        public IEnumerable<OrderImp> GetAllOrders()
        {
            return Mapper.Map(_db.Orders.Include(o => o.OrderGames).ThenInclude(i => i.Game));
        }

        public IEnumerable<OrderImp> GetOrderByDate(StoreImp store)
        {
            //foreach (OrderImp r in _Data)
            //{
            //    yield return r;
            //}
            return Mapper.Map(_db.Orders.OrderBy(r => r.OrderDate).Where(r => r.OrderStoreId == store.IDNumber));
        }

        public IEnumerable<OrderImp> GetOrderByDateReverse(StoreImp store)
        {
            //foreach (OrderImp r in _Data)
            //{
            //    yield return r;
            //} 
            return Mapper.Map(_db.Orders.OrderByDescending(r => r.OrderDate).Where(r => r.OrderStoreId == store.IDNumber));

        }

        public IEnumerable<OrderImp> GetOrderByCost(StoreImp store)
        {
            return Mapper.Map(_db.Orders.OrderBy(r => r.OrderCost).Where(r => r.OrderStoreId == store.IDNumber));
        }

        public IEnumerable<OrderImp> GetOrderByCostReverse(StoreImp store)
        {
            return Mapper.Map(_db.Orders.OrderByDescending(r => r.OrderCost).Where(r => r.OrderStoreId == store.IDNumber));

        }

        public OrderImp GetExactOrderByDate(DateTime dt)
        {
            return Mapper.Map(_db.Orders.First(o => o.OrderDate == dt));
        }

        public IEnumerable<OrderImp> GetAllOrdersByCustomer(int Id)
        {
            var value = _db.Orders.Where(o => o.OrderCustomerId == Id);
            return Mapper.Map(value);
        }

        public int GetMostPopularGame()
        {
            var value = _db.OrderGames.GroupBy(o => o.GameId).Select(g => new { GameId = g.Key, Sum = g.Sum(o => o.GameQuantity) }).OrderBy(x => x.Sum);
            return value.First().GameId;            
        }

        public void DeactiveOrder(OrderImp order)
        {
            order.Valid = false;
        }

        public void AddOrder(OrderImp order)
        {
            var value = Mapper.Map(order);
            _db.Add(value);
            _db.SaveChanges();
            order.OrderID = value.OrderId;
        }

        public void AddOrderItem(OrderGamesImp _orderGame)
        {
            OrderGamesImp orderGame = _orderGame;
            orderGame.Price = orderGame.GetCostOfPurchase();
            _db.OrderGames.Add(Mapper.Map(orderGame));
            _db.SaveChanges();
            //if (restaurant != null)
            //{
            //    // get the db's version of that restaurant
            //    // (can't use Find with Include)
            //    var contextRestaurant = _db.Restaurant.Include(r => r.Review).First(r => r.Id == restaurant.Id);
            //    restaurant.Reviews.Add(review);
            //    contextRestaurant.Review.Add(Mapper.Map(review));
            //}
            //else
            //{
            //    _db.Add(Mapper.Map(review));
            //}
        }

        public bool IsValidId(int Id)
        {
            var value = _db.Orders.Find(Id);
            return value != null;
        }

    }
}
