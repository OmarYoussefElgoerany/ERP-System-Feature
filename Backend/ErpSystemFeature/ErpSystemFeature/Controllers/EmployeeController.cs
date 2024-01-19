using ErpSystemFeatureBLL.DTOs.EmployeeDto;
using ErpSystemFeatureBLL.Managers.CustomerManager;
using Microsoft.AspNetCore.Mvc;


namespace ErpSystemFeatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDto>>? GetAll()
        {
            var emps = employeeManager.GetAll();
            if (emps == null)
                return NoContent();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetById(int id)
        {
            if(id == 0) 
                return BadRequest();
            var getEmp = employeeManager.GetById(id);
            if (getEmp == null)
                return NoContent();
            return Ok(getEmp);
        }
    }
}
