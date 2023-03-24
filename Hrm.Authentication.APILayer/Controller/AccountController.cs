using JWTAuthenticationManager;
using JWTAuthenticationManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hrm.Authentication.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler jwtTokenHandler;
        public AccountController(JwtTokenHandler _jwtTokenHandler)
        {
            jwtTokenHandler = _jwtTokenHandler;
        }


        [HttpPost]
        public ActionResult<AuthenticationResponseModel> Login(AuthenticationRequestModel model)
        {
            var response = jwtTokenHandler.GenerateJwtToken(model);
            if (response == null)
            {
                //this is a predefined response
                return Unauthorized();
            }
            return response;
        }
    }
}
