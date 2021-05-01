namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class AppRoleTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();
            internal const string TableName = "app_role";

            internal static class Column
            {
                internal const string ConcurrencyStamp = "concurrency_stamp";
                internal const string Id = "id";
                internal const string Name = "name";
                internal const string NormalizedName = "normalized_name";
            }

            internal static class Index
            {
                internal static readonly string NormalizedName = $"uix_{_shortSchemaName}_{_shortTableName}_normalizedname";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{_shortTableName}_id";
                internal static readonly string RoleIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_roleid";
            }
        }
    }
}
