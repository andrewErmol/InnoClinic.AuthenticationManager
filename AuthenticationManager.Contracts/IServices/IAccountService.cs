using AuthenticationManager.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Contracts.IServices
{
    public interface IAccountService
    {
        public Task<AuthenticatedAccountInfoDto> AuthenticateAccount(AccountForAuthenticationDto account);
        public Task<string> CreateAccount(AccountForCreationDto accountForCreation);
        public Task AddRoleToAccount(string login, string role);
        public Task RemoveRoleFromAccount(string login, string role);
    }
}
