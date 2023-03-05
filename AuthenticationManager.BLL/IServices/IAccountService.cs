using AuthenticationManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.BLL.IServices
{
    public interface IAccountService
    {
        public Task CreateAccount(AccountForCreation accountForCreation);
        public Task AddRoleToAccount(string login, string role);
        public Task RemoveRoleFromAccount(string login, string role);
    }
}
