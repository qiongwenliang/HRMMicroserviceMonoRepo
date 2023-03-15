using Hrm.Interview.ApplicationCore.Contract.Service;

using Hrm.Interview.ApplicationCore.Model.Request;
using Hrm.Interview.ApplicationCore.ModelRef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Interview.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {


        private readonly IInterviewsServiceAsync interviewsServiceAsync;
        private readonly HttpClient httpClient = new HttpClient();
        private readonly IConfiguration config;

        public InterviewsController(IInterviewsServiceAsync _interviewsServiceAsync, IConfiguration config)
        {
            interviewsServiceAsync = _interviewsServiceAsync;
            this.config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewsRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewsServiceAsync.AddInterviewsAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }


        [HttpGet("candidate")]
        public async Task<IActionResult> GetCandidate()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("RecruitingApiUrl").Value);
            //this RecruitingApiUrl is configured in appsetting.json
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CandidateModel>>(httpClient.BaseAddress + "candidate");
            return Ok(result);
        }


        [HttpGet("submission")]
        public async Task<IActionResult> GetSubmission()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("RecruitingApiUrl").Value);
            //this RecruitingApiUrl is configured in appsetting.json
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SubmissionModel>>(httpClient.BaseAddress + "submission");
            return Ok(result);
        }





        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewsServiceAsync.GetAllInterviewsAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewsServiceAsync.GetInterviewsByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Put(InterviewsRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await interviewsServiceAsync.UpdateInterviewsAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await interviewsServiceAsync.GetInterviewsByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }

            await interviewsServiceAsync.DeleteInterviewsAsync(id);
            return Ok("Deleted");
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployee()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("OnboardingApiUrl").Value);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EmployeeModel>>(httpClient.BaseAddress + "employee");
            return Ok(result);
        }

    }
}
