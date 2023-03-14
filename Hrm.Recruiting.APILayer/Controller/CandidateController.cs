using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.ApplicationCore.Model;
using Hrm.Recruiting.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        private readonly IBlobServiceAsync blobServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync, IBlobServiceAsync _blobServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
            blobServiceAsync = _blobServiceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await candidateServiceAsync.GetAllCandidateAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This candidate doesn't exist!");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CandidateRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Wrong Update");
            var result = await candidateServiceAsync.UpdateCandidateAsync(model);
            if (result == null) { return BadRequest("Wrong Update"); }
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            if (result == null)
            {
                return BadRequest("This candidate doesn't exist!");
            }

            await candidateServiceAsync.DeleteCandidateAsync(id);
            return Ok("Deleted");
        }



        //Azure Blob Storage settings
        [HttpPost("resume")]
        public async Task<IActionResult> UploadResume(BlobModel model)
        {
            await blobServiceAsync.UploadFileAsync(model.filePath, model.fileName);
            return Ok();
        }


        [HttpDelete("deleteResume")]
        public async Task<IActionResult> DeleteResume(string fileName)
        {
            try
            {
                await blobServiceAsync.DeleteFileAsync(fileName);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
