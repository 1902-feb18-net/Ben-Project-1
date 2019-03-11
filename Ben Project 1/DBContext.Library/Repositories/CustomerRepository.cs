using DBContext.Library;
using Project_1.BLL.Library.Implementation;
using Project_1.BLL.Library.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_1.DBContext.Library.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Project0Context _db;

        public CustomerRepository(Project0Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<CustomerImp> GetCustomers()
        {
            return Mapper.Map(_db.Customers);
        }

        public CustomerImp GetCustomerById(int Id)
        {
            var value = _db.Customers.Find(Id) ?? throw new ArgumentException("Must be valid Customer ID");
            return Mapper.Map(value);
        }

        public bool IsValidId(int Id)
        {
            var value = _db.Customers.Find(Id);
            return value != null;
        }

        public CustomerImp GetCustomerByName(string fullName)
        {
            var value = _db.Customers.First(c => c.FirstName + " " + c.LastName == fullName) ?? throw new ArgumentException("Must be valid customer name");
            return Mapper.Map(value);
        }

        public void AddCustomer(CustomerImp _customer)
        {
            var value = Mapper.Map(_customer);
            _db.Add(value);
            _db.SaveChanges();
            _customer.Id = value.CustomerId;
        }

        public void EditCustomer(CustomerImp _customer)
        {
            _db.Entry(_db.Customers.Find(_customer.Id)).CurrentValues.SetValues(Mapper.Map(_customer));
            _db.SaveChanges();
        }

    }
}
