using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using NoteWorx.Notes.Data.Models;

namespace NoteWorx.Identity.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public virtual ICollection<AppUserClaim> Claims { get; set; } = null!;
        public virtual ICollection<AppUserLogin> Logins { get; set; } = null!;
        public virtual ICollection<AppUserToken> Tokens { get; set; } = null!;
        public virtual ICollection<AppUserRole> UserRoles { get; set; } = null!;
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
