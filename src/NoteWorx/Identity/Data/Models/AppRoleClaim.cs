using System;
using Microsoft.AspNetCore.Identity;

namespace NoteWorx.Identity.Data.Models
{
    public class AppRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual AppRole Role { get; set; } = null!;
    }
}
