

using AuthenticationManager.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationManager.Domain.Models
{
    public class Account : IdentityUser
    {
        public string PhoneNumber { get; set; }
        public AccountStatus Status { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid PhotoId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
