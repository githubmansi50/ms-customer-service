using Microsoft.AspNetCore.Mvc;
using CustomerService.Data;
using CustomerService.Models;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Customers.ToList());

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = customer.CustomerID }, customer);
        }
    }
}
