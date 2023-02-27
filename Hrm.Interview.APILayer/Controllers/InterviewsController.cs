using Hrm.Interview.ApplicationCore.Contract.Service;
using Hrm.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Interview.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewsServiceAsync interviewsServiceAsync;

        public InterviewsController(IInterviewsServiceAsync _interviewsServiceAsync)
        {
            interviewsServiceAsync = _interviewsServiceAsync;
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
    }
}
