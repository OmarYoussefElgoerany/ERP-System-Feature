using ErpSystemFeatureBLL.DTOs.CustomerDto;
using ErpSystemFeatureBLL.Managers.EmployeeManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemFeatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }
        [HttpGet]
        public ActionResult<List<ReadCustomerDto>>? GetAll()
        {
            var customers = customerManager.GetAll();
            if (customers == null)
                return NoContent();
            return customers;
        }
        [HttpGet("{id}")]
        public ActionResult<ReadCustomerDto>? GetById(int id)
        {
            var customer = customerManager.GetById(id);
            if (customer == null)
                return NoContent();
            return customer;
        }
        [HttpGet("{page}/{countPerPage}")]
        public ActionResult<CustomerPaginationDto>? GetAllPerPage(int page, int countPerPage)
        {
            if(page <= 0 ||  countPerPage <= 0) 
                return BadRequest();
            var customers = customerManager.GetAllPerPage(page,countPerPage);
            if (customers == null)
                return NoContent();
            return customers;
        }
        [HttpPost]
        public ActionResult isAdded(AddCustomerDto customerDto)
        {
            if (customerDto == null)
                return BadRequest();
            var isAdded = customerManager.isAdded(customerDto);
            if (isAdded == false)
                return BadRequest();
            return Ok(customerDto);
        }
        [HttpPut]
        public ActionResult isUpdated(ReadCustomerDto customerDto)
        {

            if (customerDto == null)
                return BadRequest();
            var isUpdated = customerManager.isUpdated(customerDto);
            if (isUpdated == false)
                return BadRequest();
            return Ok(customerDto);
        }
        [HttpDelete("{id}")]
        public ActionResult isDeleted(int id)
        {
            if (id == 0)
                return BadRequest();
            var isDeleted = customerManager.isDeleted(id);
            if (isDeleted == false)
                return BadRequest();
            return Ok();
        }
    }
}
