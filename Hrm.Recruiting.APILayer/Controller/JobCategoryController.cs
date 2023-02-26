using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryServiceAsync jobCategoryServiceAsync;
        public JobCategoryController(IJobCategoryServiceAsync _jobCategoryServiceAsync)
        {
            jobCategoryServiceAsync = _jobCategoryServiceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> Post(JobCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobCategoryServiceAsync.AddJobCategoryAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobCategoryServiceAsync.GetAllJobCategoryAsync();
            return Ok(result);  
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            if (result != null)
            {
                await jobCategoryServiceAsync.DeleteJobCategoryAsync(id);
                return Ok();
            }
            return BadRequest(result);
        }
    }
}
