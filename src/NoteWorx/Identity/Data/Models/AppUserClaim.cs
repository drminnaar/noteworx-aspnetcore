using System;
using Microsoft.AspNetCore.Identity;

namespace NoteWorx.Identity.Data.Models
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
        public virtual AppUser User { get; set; } = null!;
    }
}
