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
            if(temp > 0)
            {
                result=true;
            }
            return result;
        }
    }
}
