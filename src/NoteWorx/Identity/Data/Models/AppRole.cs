using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NoteWorx.Identity.Data.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; } = null!;
        public virtual ICollection<AppRoleClaim> RoleClaims { get; set; } = null!;
    }
}
