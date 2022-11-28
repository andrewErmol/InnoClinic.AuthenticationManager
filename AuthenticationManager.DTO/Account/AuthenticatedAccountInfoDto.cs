using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.DTO.Account
{
    public class AuthenticatedAccountInfoDto
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public IList<string> UserRoles { get; set; }
    }
}
