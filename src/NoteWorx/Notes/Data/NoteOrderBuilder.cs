using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Notes.Data.Models;

namespace NoteWorx.Notes.Data
{
    public sealed class NoteOrderBuilder : EntityOrderBuilderBase<Note>
    {
        protected override IDictionary<string, Expression<Func<Note, object>>> CreateSelectorLookup()
        {
            return new Dictionary<string, Expression<Func<Note, object>>>()
            {
                { "createdat", e => e.CreatedAt },
                { "modifiedat", e => e.ModifiedAt },
                { "title", e => e.Title},
                { "username", e => e.User.UserName }
            };
        }
    }
}
