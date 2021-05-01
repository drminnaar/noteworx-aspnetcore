
namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class AppUserClaimTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();

            internal const string TableName = "app_user_claim";

            internal static class Column
            {
                internal const string ClaimType = "claim_type";
                internal const string ClaimValue = "claim_value";
                internal const string Id = "id";
                internal const string UserId = "user_id";
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
