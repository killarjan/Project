using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UserManagementSystem.Models.Users.Responses;

namespace UserManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MockServerController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory = null;

        public MockServerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Call()
        {            
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                MockServerResponse? mockServerResponse = await client.GetFromJsonAsync<MockServerResponse>("https://3vw153md8d.api.quickmocker.com/test");

                return Ok(mockServerResponse);
            }
        }
    }
}   
