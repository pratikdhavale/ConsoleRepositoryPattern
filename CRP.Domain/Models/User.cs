using CRP.Common;
using CRP.Domain.Infrastructure;

namespace CRP.Domain.Models
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
