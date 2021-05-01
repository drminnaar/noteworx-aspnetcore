using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteWorx.Identity.Data.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public virtual AppUser User { get; set; } = null!;
        public Guid UserId { get; set; }
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(5);
        public DateTime? RevokedAt { get; set; }
    }
}
