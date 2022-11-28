using AuthenticationManager.Contracts.IServices;
using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.Account;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationManager.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAuthManager _authManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Account> _accountManager;

        public AccountService(UserManager<Account> accountManager, IMapper mapper, RoleManager<IdentityRole> roleManager,
            IAuthManager authManager)
        {
            _accountManager = accountManager;
            _roleManager = roleManager;
            _authManager = authManager;
            _mapper = mapper;
        }

        public async Task AddRoleToAccount(string login, string role)
        {
            Account account = await _accountManager.FindByNameAsync(login);

            if (account == null)
                throw new Exception("Account not found");

            if (!await _roleManager.RoleExistsAsync(role))
                throw new Exception("Role not exists");

            await _accountManager.AddToRoleAsync(account, role);
        }

        public async Task RemoveRoleFromAccount(string login, string role)
        {
            Account account = await _accountManager.FindByNameAsync(login);

            if (account == null)
                throw new Exception("Account not found");

            if (!await _roleManager.RoleExistsAsync(role))
                throw new Exception("Role not exists");

            await _accountManager.RemoveFromRoleAsync(account, role);
        }

        public async Task<AuthenticatedAccountInfoDto> AuthenticateAccount(AccountForAuthenticationDto account)
        {
            Account validAccount = await _authManager.ReturnAccountIfValid(account);

            if (validAccount == null) throw new Exception("Wrong username or password");

            (string accessToken, string refreshToken) tokens = await _authManager.GetTokens(account);

            return new AuthenticatedAccountInfoDto
            {
                AccessToken = tokens.accessToken,
                RefreshToken = tokens.refreshToken,
                UserRoles = await _accountManager.GetRolesAsync(validAccount)
            };
        }

        public async Task<string> CreateAccount(AccountForCreationDto accountForCreation)
        {
            Account account = _mapper.Map<Account>(accountForCreation);

            IdentityResult result = await _accountManager.CreateAsync(account, accountForCreation.Password);

            if (!result.Succeeded)
            {
                string errors = "";
                foreach (IdentityError error in result.Errors) errors += $"{error.Code}: {error.Description}\n";
                throw new Exception(errors);
            }

            return "success";
        }
    }
}
