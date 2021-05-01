namespace NoteWorx.Notes.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class NoteTable
        {
            internal const string TableName = "note";

            internal static class Column
            {
                public const string Id = "id";
                public const string Title = "title";
                public const string Description = "description";
                public const string CreatedAt = "created_at";
                public const string ModifiedAt = "modified_at";
                public const string Tags = "tags";
                public const string UserId = "user_id";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{TableName}_id";
            }
        }
    }
}
