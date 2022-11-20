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
            custs = customers.ToList();
            return View(custs);
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer customer)
        {
            if (_customerRepository.InsertCustomer(customer))
            {
                return RedirectToAction("Index","Home");
            }
            return Json(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            if (customer.Name == null)
            {
                return View(customer);
            }
            _customerRepository.UpdateCustomer(customer);
            return new EmptyResult();
        }
        [HttpPost]
        public ActionResult DeleteCustomer(string customerId)
        {
            if (customerId == "0" || customerId == null)
            {
                return View(nameof(Index));
            }
            _customerRepository.DeleteCustomer(Convert.ToInt32(customerId));
            return new EmptyResult();
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