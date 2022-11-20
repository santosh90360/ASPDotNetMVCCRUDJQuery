using ASPDotNetMVCCRUDJQuery.Models;

namespace ASPDotNetMVCCRUDJQuery.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
    }
}
