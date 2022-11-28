using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Contracts.IServices
{
    public interface IAuthManager
    {
        Task<Account> ReturnAccountIfValid(AccountForAuthenticationDto accountForAuthentication);
        Task<(string accessToken, string refreshToken)> GetTokens(AccountForAuthenticationDto account);
    }
}
