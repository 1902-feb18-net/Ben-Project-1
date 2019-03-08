using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.BLL.Library.Implementation
{
    public class StoreImp
    {
        public StoreImp()
        {

        }

        public StoreImp(string Local)
        {
            Items = new InventoryImp();
            Location = Local;
        }

        private string _location;

        public string Location //the location of store???
        {
            get => _location;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Location name must not be empty", nameof(value));
                }
                _location = value;
            }
        }

        private double _distance;

        public double Distance //player enters distance in miles to help calc shipping costs

        {
            get => _distance;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Distance cannot be negative", nameof(value));
                }
                _distance = value;
            }
        }

        private decimal _shippingCosts;

        public decimal ShippingCosts //distance is multiplied by some num for costs
        {
            get => _shippingCosts;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("shipping costs cannot be negative", nameof(value));
                }
                _shippingCosts = value;
            }
        } 

        public int IDNumber { get; set; } //ID numbers start at 1 and increment for every order
        public DateTime OrderDate { get; set; } //Player inputs date, can be used to help find Orders
        public CustomerImp Cust { get; set; } //Player inputs customers name, can be used to find Orders

        public InventoryImp Items { get; set; } //the store's inventory class
        public int DeluxeInStock { get; set; } //A hidden number that limits Delux orders

        public bool LastBoughtGameIsIsekai { get; set; } //true indicates last bought game was Isekai, false indicates Shonen

        public double TotalCost { get; } //the total cost of all items bought by customer

        //public decimal GetGameCost(GamesImp game, string edition)
        //{
        //    //depending on game edition, return the correct price
        //    if (edition == "Base")
        //        return game.Cost;
        //    else if (edition == "Advanced")
        //        return game.AdvancedCost;
        //    else if (edition == "Deluxe") 
        //        return game.DeluxeCost;
        //    else
        //        return 0;
        //}

        public List<OrderImp> ListOfOrders; 
        
        public bool CheckIfOrderIsReady(CustomerImp customer)
        {
            for (int i = 0; i < ListOfOrders.Count; i++)
            {
                if (ListOfOrders[i].OrderCustomer == customer.Id)
                {
                    DateTime dateTime1 = ListOfOrders[i].OrderDate;
                    DateTime dateTime2 = DateTime.Now;
                    if (dateTime2.Hour - dateTime1.Hour >= 2) { }
                    else
                        return false;
                }
            }
            return true;
        }

        public bool RecommendedGame()
        {
            //if the last bought game was Isekai, return false (Shonen)
            //if the last bought game was Shonen, return true (Isekai)
            //will bring up advanced edition as default
            if (LastBoughtGameIsIsekai)
                return true;
            else
                return false;
        }

    }
}
