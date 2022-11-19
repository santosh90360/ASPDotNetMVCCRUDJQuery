using ASPDotNetMVCCRUDJQuery.Models;
using ASPDotNetMVCCRUDJQuery.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPDotNetMVCCRUDJQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;
        public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetCustomers();
            List<Customer> custs = new List<Customer>();
            custs = customers.ToList(); ;
            return View(custs);
        }
        [HttpPost]
        public JsonResult InsertCustomer(Customer customer)
        {            
            _customerRepository.InsertCustomer(customer);
            return Json(customer);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}