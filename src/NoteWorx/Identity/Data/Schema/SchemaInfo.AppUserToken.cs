
namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class AppUserTokenTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();

            internal const string TableName = "app_user_token";

            internal static class Column
            {
                internal const string LoginProvider = "login_provider";
                internal const string Name = "name";
                internal const string UserId = "user_id";
                internal const string Value = "value";
            }

            internal static class Index
            {
                internal static readonly string UserId = $"ix_{_shortSchemaName}_{_shortTableName}_userid";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{_shortTableName}_loginproviderkey";
                internal static readonly string UserIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_userid";
            }
        }
    }
}
