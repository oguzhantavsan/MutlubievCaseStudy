using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MutlubievAPI.Data;
using MutlubievAPI.Dtos;
using MutlubievAPI.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq;

namespace MutlubievAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffrepo;
        private readonly DataContext _context;

        public StaffController(IStaffRepository staffrepo, DataContext context = null)
        {
            _staffrepo = staffrepo;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCleaningStaff(CleaningStaffDto cleaningStaffDto)
        {
            //if regsitration is not successful
            //I returns true or false
            if(!await _staffrepo.RegisterCleaningStaff(cleaningStaffDto))
            {
                return BadRequest("Registeration not Successful");
            }
            return Ok("Registred Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCleaningStaff()
        {
            //I created this Task additionally for you to see whether registration is successful or not.
            //It returns list of Staffs
            var cleaningStaff = await _staffrepo.GetAllCleaningStaff();
            if(cleaningStaff == null)
            {
                return BadRequest("There Is Not Any Cleaning Staff");
            }

            return Ok(cleaningStaff);
        }
        //to show provinces information
        [HttpGet("getprovinces")]
        public async Task<IActionResult> GetAllProvinces()
        {
            var provinces = from p in _context.Provinces select p;
            if(provinces.Count() == 0)
            {
                return BadRequest("There is not any province");
            }

            return Ok(provinces.ToList());
        }
        //to show districts information with provincesId
        [HttpGet("getdistricts")]
        public async Task<IActionResult> GetAllDistricts()
        {
            var districts = from d in _context.Districts select d;
            if(districts.Count() == 0)
            {
                return BadRequest("There is not any province");
            }
            
            return Ok(districts.ToList());
        }
    }
}