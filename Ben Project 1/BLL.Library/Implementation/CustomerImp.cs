using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.BLL.Library.Implementation
{
    public class CustomerImp
    {
        public CustomerImp()
        {
            LastGameBoughtId = 0;
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                // "value" is the value passed to the setter.
                if (value.Length == 0)
                {
                    // good practice to provide useful messages when throwing exceptions,
                    // as well as the name of the relevant parameter if applicable.
                    throw new ArgumentException("First Name must not be empty.", nameof(value));
                }
                _firstName = value;
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                // "value" is the value passed to the setter.
                if (value.Length == 0)
                {
                    // good practice to provide useful messages when throwing exceptions,
                    // as well as the name of the relevant parameter if applicable.
                    throw new ArgumentException("Last Name must not be empty.", nameof(value));
                }
                _lastName = value;
            }
        }
        public StoreImp Default { get; set; }

        public DateTime OrderTime { get; set; }
        
        public int Id { get; set; }

        public int DefaultStoreId { get; set; }

        public List<OrderImp> OrdersByCustomer;

        public int LastGameBoughtId { get; set; }

        public bool CheckHours
        {
            get
            {
                if (OrderTime != null)
                {
                    DateTime now = DateTime.Now;
                    if ((now - OrderTime).TotalHours > 2)
                        return true;
                }
                return false;
            }
        }
    }
}
