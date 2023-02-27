using Hrm.Interview.ApplicationCore.Contract.Service;
using Hrm.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Interview.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServiceAsync recruiterServiceAsync;

        public RecruiterController(IRecruiterServiceAsync _recruiterServiceAsync)
        {
            recruiterServiceAsync = _recruiterServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RecruiterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await recruiterServiceAsync.AddRecruiterAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await recruiterServiceAsync.GetAllRecruiterAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await recruiterServiceAsync.GetRecruiterByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Put(RecruiterRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await recruiterServiceAsync.UpdateRecruiterAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await recruiterServiceAsync.GetRecruiterByIdAsync(id);
            if (result == null)
            {
                return BadRequest("No Interview");
            }

            await recruiterServiceAsync.DeleteRecruiterAsync(id);
            return Ok("Deleted");
        }
    }
}
