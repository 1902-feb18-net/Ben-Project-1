using DBContext.Library;
using Project_1.BLL.Library.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBContext.Library
{
    public static class Mapper
    {

        public static Orders Map(OrderImp Order) => new Orders
        {
            OrderId = Order.OrderID,
            OrderDate = Order.OrderDate,
            OrderCustomerId = Order.OrderCustomer,
            OrderCost = Order.TotalOrderCost(),
            OrderStoreId = Order.StoreId
        };

        public static OrderImp Map(Orders Order) => new OrderImp
        {
            OrderID = Order.OrderId,
            OrderDate = Order.OrderDate,
            OrderCustomer = Order.OrderCustomerId,
            OrderCost = Order.OrderCost,
            StoreId = Order.OrderStoreId,

            GamesInOrder = Map(Order.OrderGames).ToList(),            
        };

        public static Stores Map(StoreImp Store) => new Stores
        {
            StoreId = Store.IDNumber,
            Location = Store.Location,
            DeluxePackageRemaining = Store.DeluxeInStock,
            ShippingCosts = Store.ShippingCosts
        };

        public static StoreImp Map(Stores Store) => new StoreImp
        {
            IDNumber = Store.StoreId,
            Location = Store.Location,
            DeluxeInStock = Store.DeluxePackageRemaining,
            ShippingCosts = Store.ShippingCosts,

            ListOfOrders = Map(Store.Orders).ToList()
        };

        public static Customers Map(CustomerImp Customer) => new Customers
        {
            CustomerId = Customer.Id,
            FirstName = Customer.FirstName,
            LastName = Customer.LastName,
            DefaultStoreId = Customer.DefaultStoreId
        };

        public static CustomerImp Map(Customers Customer) => new CustomerImp
        {
            Id = Customer.CustomerId,
            FirstName = Customer.FirstName,
            LastName = Customer.LastName,
            DefaultStoreId = Customer.DefaultStoreId,

            OrdersByCustomer = Map(Customer.Orders).ToList()
        };

        public static Games Map(GamesImp Game) => new Games
        {
            GameId = Game.Id,
            GameName = Game.Name,
            StandardPrice = Game.Cost,
            AdvancedPrice = Game.AdvancedCost
        };

        public static GamesImp Map(Games Game) => new GamesImp
        {
            Id = Game.GameId,
            Name = Game.GameName,
            Cost = Game.StandardPrice,
            AdvancedCost = Game.AdvancedPrice
        };

        public static Inventory Map(InventoryImp _Inventory) => new Inventory
        {
            StoreId = _Inventory.StoreId,
            GameId = _Inventory.GameId,
            GameRemaining = _Inventory.GameInStock
        };

        public static InventoryImp Map(Inventory _Inventory) => new InventoryImp
        {
            StoreId = _Inventory.StoreId,
            GameId = _Inventory.GameId,
            GameInStock = _Inventory.GameRemaining
        };

        public static OrderGames Map(OrderGamesImp OrderGame) => new OrderGames
        {
            OrderId = OrderGame.OrderId,
            GameId = OrderGame.GameId,
            GameQuantity = OrderGame.GameQuantity,
            Edition = OrderGame.Edition,
            Price = OrderGame.Price
        };

        public static OrderGamesImp Map(OrderGames OrderGame) => new OrderGamesImp
        {
            OrderId = OrderGame.OrderId,
            GameId = OrderGame.GameId,
            GameQuantity = OrderGame.GameQuantity,
            Edition = OrderGame.Edition,
            Price = OrderGame.Price,
            
            Game = Map(OrderGame.Game)
        };

        //Order
        public static IEnumerable<Orders> Map(IEnumerable<OrderImp> Order) => Order.Select(Map);

        public static IEnumerable<OrderImp> Map(IEnumerable<Orders> Order) => Order.Select(Map);

        //Store
        public static IEnumerable<Stores> Map(IEnumerable<StoreImp> Store) => Store.Select(Map);

        public static IEnumerable<StoreImp> Map(IEnumerable<Stores> Store) => Store.Select(Map);

        //Customer
        public static IEnumerable<Customers> Map(IEnumerable<CustomerImp> Customer) => Customer.Select(Map);

        public static IEnumerable<CustomerImp> Map(IEnumerable<Customers> Customer) => Customer.Select(Map);

        //Game
        public static IEnumerable<Games> Map(IEnumerable<GamesImp> Game) => Game.Select(Map);

        public static IEnumerable<GamesImp> Map(IEnumerable<Games> Game) => Game.Select(Map);

        //Inventory
        public static IEnumerable<Inventory> Map(IEnumerable<InventoryImp> _Inventory) => _Inventory.Select(Map);

        public static IEnumerable<InventoryImp> Map(IEnumerable<Inventory> _Inventory) => _Inventory.Select(Map);

        //OrderGames
        public static IEnumerable<OrderGames> Map(IEnumerable<OrderGamesImp> OrderGame) => OrderGame.Select(Map);

        public static IEnumerable<OrderGamesImp> Map(IEnumerable<OrderGames> OrderGame) => OrderGame.Select(Map);
    }



}

