namespace NoteWorx.Identity.Data.Schema
{
    internal static partial class SchemaInfo
    {
        internal static class AppUserTable
        {
            private static readonly string _shortTableName = TableName.Replace("_", "").ToLower();

            internal const string TableName = "app_user";

            internal static class Column
            {
                internal const string AccessFailedCount = "access_failed_count";
                internal const string ConcurrencyStamp = "concurrency_stamp";
                internal const string Email = "email";
                internal const string EmailConfirmed = "email_confirmed";
                internal const string Id = "id";
                internal const string LockoutEnabled = "lockout_enabled";
                internal const string LockoutEnd = "lockout_end";
                internal const string NormalizedEmail = "normalized_email";
                internal const string NormalizedUserName = "normalized_username";
                internal const string PasswordHash = "password_hash";
                internal const string PhoneNumber = "phone_number";
                internal const string PhoneNumberConfirmed = "phone_number_confirmed";
                internal const string SecurityStamp = "security_stamp";
                internal const string TwoFactorEnabled = "two_factor_enabled";
                internal const string UserName = "username";
            }

            internal static class Index
            {
                internal static readonly string NormalizedUserName = $"uix_{_shortSchemaName}_{_shortTableName}_normalizedusername";
                internal static readonly string NormalizedEmail = $"ix_{_shortSchemaName}_{_shortTableName}_normalizedemail";
            }

            internal static class Key
            {
                internal static readonly string PrimaryKey = $"pk_{_shortSchemaName}_{_shortTableName}_id";
                internal static readonly string ClaimIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_claimid";
                internal static readonly string LoginIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_loginid";
                internal static readonly string UserIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_userid";
                internal static readonly string TokenIdForeignKey = $"fk_{_shortSchemaName}_{_shortTableName}_tokenid";
            }
        }
    }
}
