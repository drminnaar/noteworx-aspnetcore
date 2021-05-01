
namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class RefreshTokenTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();

            internal const string TableName = "refresh_token";

            internal static class Column
            {
                internal const string Id = "id";
                internal const string UserId = "user_id";
                internal const string Value = "value";
                internal const string ExpiresAt = "expires_at";
                internal const string RevokedAt = "revoked_at";
                internal const string IsExpired = "is_expired";
                internal const string IsActive = "is_active";
            }

            internal static class Index
            {
                internal static readonly string UserId = $"ix_{_shortSchemaName}_{_shortTableName}_userid";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{_shortTableName}_id";
                internal static readonly string UserIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_userid";
            }
        }
    }
}
