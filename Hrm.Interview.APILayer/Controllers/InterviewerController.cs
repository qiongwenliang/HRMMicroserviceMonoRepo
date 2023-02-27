using Hrm.Interview.ApplicationCore.Contract.Service;
using Hrm.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Interview.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync interviewerServiceAsync;

        public InterviewerController(IInterviewerServiceAsync _interviewerServiceAsync)
        {
            interviewerServiceAsync = _interviewerServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewerServiceAsync.AddInterviewerAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewerServiceAsync.GetAllInterviewerAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewerServiceAsync.GetInterviewerByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Put(InterviewerRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await interviewerServiceAsync.UpdateInterviewerAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await interviewerServiceAsync.GetInterviewerByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }

            await interviewerServiceAsync.DeleteInterviewerAsync(id);
            return Ok("Deleted");
        }
    }
}
