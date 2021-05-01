using System;
using System.Linq.Expressions;
using NoteWorx.Notes.Data.Models;

namespace NoteWorx.Notes.Data
{
    public sealed class NoteQueryBuilder
    {
        public Expression<Func<Note, bool>> Filter { get; private set; } = ExpressionBuilder.True<Note>();

        public NoteQueryBuilder WhereTermLike(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
            {
                var normalizedTerm = term.ToLowerInvariant().Trim();

                Filter = Filter.And(n =>
                    n.Title.ToLower().Contains(normalizedTerm)
                    || n.Description.ToLower().Contains(normalizedTerm));
            }

            return this;
        }

        public NoteQueryBuilder WhereTagEquals(string tag)
        {
            if (!string.IsNullOrWhiteSpace(tag))
            {
                var normalizedTag = tag.ToLowerInvariant().Trim();

                Filter = Filter.And(n => n.Tags.Contains(tag));
            }

            return this;
        }

        public NoteQueryBuilder WhereUsernameEquals(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                var normalizedUsername = username.Trim().ToUpperInvariant();

                Filter = Filter.And(note => note.User.NormalizedUserName == normalizedUsername);
            }

            return this;
        }
    }
}
