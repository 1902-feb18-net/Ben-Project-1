using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.BLL.Library.Implementation
{
    public class InventoryImp
    {
        public int IsekaiInStock { get; set; } //A hidden number that limits Isekai orders
        public int ShonenAdventureInStock { get; set; } //A hidden number that limits Shonen orders

        public int StoreId { get; set; }
        public int GameId { get; set; }
        public int GameInStock { get; set; }

        public void RemoveFromStock(int number, GamesImp item)
        {
            //Runs when order is formed, includes item and possible delux objects
            //Checks if delux is true, if so, remove from DeluxInStock as well
            //If anything being removed doesn't have any more stock available, throw error message

        }

        public bool CheckStock(int number, GamesImp item,  bool delux)
        {
            if (item.Name == "Isekai Quest")
            {
                if (IsekaiInStock < number)
                    return false;               
            }

            if (item.Name == "Shonen Adventure")
            {
                if (ShonenAdventureInStock < number)
                    return false;
            }

            return true;
        }

        public void AddToStock(int number, string item, bool delux)
        {
            //Runs when order is cancelled or stock is refilled
        }

        public void RestockAll()
        {
            //Sets all stocks back to full
        }
    }
}
