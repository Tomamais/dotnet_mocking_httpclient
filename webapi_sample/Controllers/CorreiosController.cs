using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreiosController : ControllerBase
    {
        HttpClient client;

        public CorreiosController(HttpClient client)
        {
            this.client = client;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Uri uri = new Uri("http://viacep.com.br/ws/01001000/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await this.client.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content.ReadAsStringAsync());
            }

            return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync());
        }
    }
}
