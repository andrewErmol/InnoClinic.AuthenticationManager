using AuthenticationManager.Contracts.IServices;
using AuthenticationManager.DTO.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AccountForCreationDto accountForCreation)
        {
            if (await _accountService.CreateAccount(accountForCreation) == "success")
            {
                return Ok("success");
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountForAuthenticationDto account)
        {
            AuthenticatedAccountInfoDto accountInfo = await _accountService.AuthenticateAccount(account);
            return Ok(accountInfo);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("AddRole")]
        [Authorize]
        public async Task<IActionResult> AddRoleToUser([FromQuery] string login, [FromQuery] string role)
        {
            await _accountService.AddRoleToAccount(login, role);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteRole")]
        [Authorize]
        public async Task<IActionResult> RemoveRoleFromUser([FromQuery] string login, [FromQuery] string role)
        {
            await _accountService.RemoveRoleFromAccount(login, role);
            return Ok();
        }
    }
}
