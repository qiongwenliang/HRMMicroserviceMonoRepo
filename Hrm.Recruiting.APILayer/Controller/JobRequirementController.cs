using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.ApplicationCore.Model.Request;
using Hrm.Recruiting.ApplicationCore.ModelRef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;
        private readonly HttpClient httpClient = new HttpClient();
        private readonly IConfiguration config;
        

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync, IConfiguration config)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
            this.config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployee()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("OnboardingApiUrl").Value);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EmployeeModel>>(httpClient.BaseAddress + "employee");
            return Ok(result);
        }

        [HttpGet("employeecategory")]
        public async Task<IActionResult> GetEmployeeCategory()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("OnboardingApiUrl").Value);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EmployeeCategoryModel>>(httpClient.BaseAddress + "employeecategory");
            return Ok(result);
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobRequirementServiceAsync.GetAllJobRequirementAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We dont' have this Job Requirement");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            if (result == null)
            {
                return BadRequest("We dont' have this Job Requirement");
            }

            await jobRequirementServiceAsync.DeleteJobRequirementAsync(id);
            return Ok("Deleted");
        }
    }
}
