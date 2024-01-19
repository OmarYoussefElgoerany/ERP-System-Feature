using ErpSystemFeatureBLL.DTOs.CallsDto;
using ErpSystemFeatureBLL.DTOs.CustomerDto;
using ErpSystemFeatureBLL.Managers.CallsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemFeatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallsController : ControllerBase
    {
        private readonly ICallsManager callsManager;

        public CallsController(ICallsManager callsManager)
        {
            this.callsManager = callsManager;
        }

        [HttpGet]
        public ActionResult<ReadCallsDto> GetAll()
        {           
            var calls = callsManager.GetAll();
            if (calls == null)
                return NoContent();
     
            return Ok(calls);
        }
        [HttpGet("{page}/{countPerPage}")]
        public ActionResult<List<ReadCustomerDto>>? GetAllPerPage(int page, int countPerPage)
        {
               if (page <= 0 || countPerPage <= 0)
                return BadRequest();
            var calls = callsManager.GetAllPerPage(page,countPerPage);
            if (calls == null)
                return NoContent();

            return Ok(calls);
        }

        [HttpPost]
        public ActionResult Add(AddCallsDto addCallsDto)
        {
            if (addCallsDto == null)
                return BadRequest();
            var addedCall =callsManager.isAdded(addCallsDto);
            if(addedCall == false)
                return BadRequest();
            return Ok();
        }
    }
}
