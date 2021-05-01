using System;
using Microsoft.AspNetCore.Identity;

namespace NoteWorx.Identity.Data.Models
{
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
        public virtual AppUser User { get; set; } = null!;
    }
}
