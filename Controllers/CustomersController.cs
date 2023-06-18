using Entities.Models;
using Repositories.EFCore; 
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contract;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public CustomersController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _manager.customerServices.GetAllCustomers(false);

                return Ok(customers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCustomer([FromRoute(Name = "id")] int id)
        {
            try
            {

                var customer = _manager.customerServices.GetOneCustomerById(id,false);

                if (customer is null)
                    return NotFound(); //404

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer is null)
                    return BadRequest(); // 400 

                _manager.customerServices.CreateOneCustomer(customer);
                

                return StatusCode(201, customer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCustomer([FromRoute(Name = "id")] int id,
            [FromBody] Customer customer)
        {
            try
            {
                if(customer is null)
                    return BadRequest();

                // check id
                if (id != customer.Id)
                    return BadRequest(); // 400

                _manager.customerServices.UpdateOneCustomer(id,customer,true);

                return NoContent();//204
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCustomer([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.customerServices.DeleteCustomer(id,false);

                return NoContent();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCustomer([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Customer> customerPatch)
        {
            try
            {
                // check entity
                var entity = _manager.customerServices.GetOneCustomerById(id, true);

                if (entity is null)
                    return NotFound(); // 404

                customerPatch.ApplyTo(entity);
                _manager.customerServices.UpdateOneCustomer(id,entity,true);
               

                return NoContent(); // 204

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
