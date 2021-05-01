using System;
using Microsoft.AspNetCore.Identity;

namespace NoteWorx.Identity.Data.Models
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public virtual AppUser User { get; set; } = null!;
        public virtual AppRole Role { get; set; } = null!;
    }
}
