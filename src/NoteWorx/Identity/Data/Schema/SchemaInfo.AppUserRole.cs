namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class AppUserRoleTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();
            internal const string TableName = "app_user_role";

            internal static class Column
            {
                internal const string RoleId = "role_id";
                internal const string UserId = "user_id";
            }

            internal static class Index
            {
                internal static readonly string RoleId = $"ix_{_shortSchemaName}_{_shortTableName}_roleid";
                internal static readonly string UserId = $"ix_{_shortSchemaName}_{_shortTableName}_userid";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{_shortTableName}_useridroleid";
                internal static readonly string RoleIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_roleid";
                internal static readonly string UserIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_userid";
            }
        }
    }
}
