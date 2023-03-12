//using Hrm.Interview.ApplicationCore.ModelRef;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;


//namespace Hrm.Interview.APILayer.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InterviewProcessController : ControllerBase
//    {

//        private readonly HttpClient httpclient = new HttpClient();
//        private readonly IConfiguration config;

//        public InterviewProcessController(IConfiguration config)
//        {
//            this.config = config;
//        }


//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            //var result = await httpclient.GetFromJsonAsync<IEnumerable<CandidateModel>>("enter url here");
//            ////means get the data from json value
//            //return Ok();

//            //httpclient.BaseAddress = new Uri("http://192.168.1.193:60887/api/");
//            //var result = await httpclient.GetFromJsonAsync<IEnumerable<CandidateModel>>(httpclient.BaseAddress + "candidate");
//            //return Ok();

//            httpclient.BaseAddress = new Uri(config.GetSection("RecruitingApiUrl").Value);
//            //this RecruitingApiUrl is configured in appsetting.json
//            var result = await httpclient.GetFromJsonAsync<IEnumerable<CandidateModel>>(httpclient.BaseAddress + "candidate");
//            return Ok(result);
//        }
//    }
//}
