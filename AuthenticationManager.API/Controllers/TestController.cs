using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
/*using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace OcelotApiGateway.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7130");
        if (disco.IsError)
        {
            return BadRequest(disco.Error);
        }

        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = disco.TokenEndpoint,

            ClientId = "client",
            ClientSecret = "secret",
            Scope = "Event.Api"
        });

        if (tokenResponse.IsError)
        {
            return BadRequest(tokenResponse.Error);
        }

        return Ok(tokenResponse);
    }
}
*/