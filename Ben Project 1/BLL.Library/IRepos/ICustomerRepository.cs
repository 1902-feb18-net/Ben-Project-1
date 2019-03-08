using Project_1.BLL.Library.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.BLL.Library.IRepos
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerImp> GetCustomers();

        CustomerImp GetCustomerById(int Id);

        bool IsValidId(int Id);

        CustomerImp GetCustomerByName(string fullName);

        void AddCustomer(CustomerImp _customer);

    }
}
