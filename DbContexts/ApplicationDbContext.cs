using ASPDotNetMVCCRUDJQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetMVCCRUDJQuery.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
