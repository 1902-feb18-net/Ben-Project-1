using DBContext.Library;
using Project_1.BLL.Library.Implementation;
using Project_1.DBContext.Library.Repositories;
using System;
using System.Linq;
using Xunit;

namespace Project1Test
{
    public class UnitTest1
    {
        readonly OrderImp orders = new OrderImp();
        private readonly Project0Context _db;

        [Fact]
        public void OrderIdIsAssignedCorrectly()
        {
            const int testId = 1;
            orders.OrderID = testId;
            Assert.Equal(orders.OrderID, testId);
        }

        [Fact]
        public void OrderDateIsAssignedCorrectly()
        {
            DateTime dateTime = DateTime.Now;
            orders.OrderDate = dateTime;

            Assert.Equal(dateTime, orders.OrderDate);
        }

        [Fact]
        public void OrderCustomerIdIsAssignedCorrectly()
        {
            const int testId = 1;
            orders.OrderCustomer = testId;
            Assert.Equal(orders.OrderCustomer, testId);
        }

        //[Fact]
        //public void OrdersReturnNullWhenThereAreNone()
        //{
        //    var repo = new OrderRepository(_db);
        //    Assert.Empty(_db.Orders.ToList());
        //}
    }
}
