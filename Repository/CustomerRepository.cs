using ASPDotNetMVCCRUDJQuery.DbContexts;
using ASPDotNetMVCCRUDJQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetMVCCRUDJQuery.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }
        public bool InsertCustomer(Customer customer)
        {
            bool result = false;
            _db.Customers.Add(customer);
            int temp = _db.SaveChanges();
            if (temp > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateCustomer(Customer customer)
        {
            bool result = false;
            Customer updatedCustomer = (from c in _db.Customers
                                        where c.CustomerId == customer.CustomerId
                                        select c).FirstOrDefault();
            updatedCustomer.Name = customer.Name;
            updatedCustomer.Country = customer.Country;
            int temp = _db.SaveChanges();
            if (temp > 0)
            {
                result = true;
            }
            return result;
        }
        public bool DeleteCustomer(int customerId)
        {
            bool result = false;
            Customer customer = (from c in _db.Customers
                                 where c.CustomerId == customerId
                                 select c).FirstOrDefault();
            _db.Customers.Remove(customer);
            int temp = _db.SaveChanges();
            if (temp > 0)
            {
                result = true;
            }
            return result;
        }       
    }
}
