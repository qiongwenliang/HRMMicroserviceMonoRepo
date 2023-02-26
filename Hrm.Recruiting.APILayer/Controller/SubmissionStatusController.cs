using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusServiceAsync submissonStatusServiceAsync;
        public SubmissionStatusController(ISubmissionStatusServiceAsync _submissonStatusServiceAsync)
        {
            submissonStatusServiceAsync = _submissonStatusServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissonStatusServiceAsync.AddSubmissionStatusAsync(model);
                return Ok();
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await submissonStatusServiceAsync.GetAllSubmissionStatusAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await submissonStatusServiceAsync.GetSubmissionStatusByIdAsync(id);    
            if (result == null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = submissonStatusServiceAsync.GetSubmissionStatusByIdAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            await submissonStatusServiceAsync.DeleteSubmissionStatusAsync(id);
            return Ok();
        }
    }
}
