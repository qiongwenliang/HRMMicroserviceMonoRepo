using Hrm.Authentication.ApplicationCore.Contract.Service;
using Hrm.Authentication.ApplicationCore.Model.Request;
using Hrm.Authentication.ApplicationCore.ModelRef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Authentication.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceAsync userServiceAsync;
        private readonly IConfiguration config;
        private readonly HttpClient httpClient = new HttpClient();

        public UserController(IUserServiceAsync _userServiceAsync, IConfiguration config)
        {
            userServiceAsync = _userServiceAsync;
            this.config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userServiceAsync.AddUserAsync(model);
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



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await userServiceAsync.GetAllUserAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await userServiceAsync.GetUserByIdAsync(id);
            if (result == null)
            {
                return BadRequest(id);
            }

            await userServiceAsync.DeleteUserAsync(id);
            return Ok("Deleted");
        }
    }
}
