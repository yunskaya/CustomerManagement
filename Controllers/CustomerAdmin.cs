using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace CustomerManagement.Controllers
{
    public class CustomerAdmin : Controller
    {
        private readonly IRepositoryManager _manager;

        public CustomerAdmin(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var Customers =  _manager.customer.GetAllCustomers(false);

            return View(Customers);
        }
    }
}
