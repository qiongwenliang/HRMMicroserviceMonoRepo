using Hrm.Onboard.ApplicationCore.Contract.Service;
using Hrm.Onboard.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Onboard.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly IEmployeeCategoryServiceAsync employeeCategoryServiceAsync;

        public EmployeeCategoryController(IEmployeeCategoryServiceAsync _employeeCategoryServiceAsync)
        {
            employeeCategoryServiceAsync = _employeeCategoryServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeCategoryServiceAsync.AddEmployeeCategoryAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeCategoryServiceAsync.GetAllEmployeeCategoryAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeCategoryServiceAsync.GetEmployeeCategoryByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee doesn't exist");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeCategoryRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await employeeCategoryServiceAsync.UpdateEmployeeCategoryAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await employeeCategoryServiceAsync.GetEmployeeCategoryByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This Employee doesn't exist");
            }

            await employeeCategoryServiceAsync.DeleteEmployeeCategoryAsync(id);
            return Ok("Deleted");
        }
    }
}
