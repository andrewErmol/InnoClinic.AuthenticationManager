using AuthenticationManager.Contracts.IServices;
using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.Account;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationManager.API.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _accountManager;

        public AuthManager(UserManager<Account> accountManager, SignInManager<Account> signInManager,
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _signInManager = signInManager;
            _accountManager = accountManager;
        }

        public async Task<Account> ReturnAccountIfValid(AccountForAuthenticationDto accountForAuth)
        {
            Account account = await _accountManager.FindByNameAsync(accountForAuth.UserName);

            SignInResult res =
                await _signInManager.PasswordSignInAsync(accountForAuth.UserName, accountForAuth.Password, false, false);

            if (res.Succeeded) return account;
            return null;
        }

        public async Task<(string accessToken, string refreshToken)> GetTokens(AccountForAuthenticationDto user)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            PasswordTokenRequest tokenRequest = new()
            {
                Address = "https://localhost:7130/connect/token",
                ClientId = "APIClient",
                Scope = "APIScope offline_access",
                UserName = user.UserName,
                Password = user.Password
            };
            TokenResponse tokenResponse = await client.RequestPasswordTokenAsync(tokenRequest);



            return (tokenResponse.AccessToken, tokenResponse.RefreshToken);
        }
    }
}
