using AuthenticationManager.BLL.IServices;
using AuthenticationManager.BLL.Models;
using AuthenticationManager.DAL.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationManager.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Account> _accountManager;

        public AccountService(UserManager<Account> accountManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _accountManager = accountManager;
            _roleManager = roleManager;
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

        public async Task CreateAccount(AccountForCreation accountForCreation)
        {
            Account account = _mapper.Map<Account>(accountForCreation);

            IdentityResult result = await _accountManager.CreateAsync(account, accountForCreation.Password);

            if (result.Succeeded)
            {
                await _accountManager.AddToRoleAsync(account, "Admin");
            }
            else
            {
                throw new Exception($"{result}");
            }
        }
    }
}
