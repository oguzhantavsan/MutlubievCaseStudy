using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MutlubievAPI.Data;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MutlubievAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _servicerepo;

        public ServiceController(IServiceRepository servicerepo)
        {
            _servicerepo = servicerepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _servicerepo.GetAllServices();
            //if there is not any service
            if(services == null)
            {
                return BadRequest("There is not any service");
            }

            return Ok(services);
        }
    }
}