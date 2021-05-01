
namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class AppRoleClaimTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();

            internal const string TableName = "app_role_claim";

            internal static class Column
            {
                internal const string ClaimType = "claim_type";
                internal const string ClaimValue = "claim_value";
                internal const string Id = "id";
                internal const string RoleId = "role_id";
            }

            internal static class Index
            {
                internal static readonly string RoleId = $"ix_{_shortSchemaName}_{_shortTableName}_roleid";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{_shortTableName}_id";
                internal static readonly string RoleIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_roleid";
            }
        }
    }
}
