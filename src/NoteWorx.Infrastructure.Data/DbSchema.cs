namespace NoteWorx.Infrastructure.Data
{
   public static class DbSchema
   {
      public static class Identity
      {
         public const string SchemaName = "identity";

         public static class Table
         {
            public static class AppUser
            {
               public const string TableName = "user";
            }

            public static class IdentityUserClaim
            {
               public const string TableName = "user_claim";
            }

            public static class IdentityUserLogin
            {
               public const string TableName = "user_login";
            }

            public static class IdentityUserRole
            {
               public const string TableName = "user_role";
            }

            public static class IdentityUserToken
            {
               public const string TableName = "user_token";
            }

            public static class IdentityRole
            {
               public const string TableName = "role";
            }

            public static class IdentityRoleClaim
            {
               public const string TableName = "role_claim";
            }
         }
      }

      public static class Notes
      {
         public const string SchemaName = "notes";

         public static class Table
         {
            public static class Note
            {
               public const string TableName = "note";

               public static class Column
               {
                  public const string Id = "id";
                  public const string Title = "title";
                  public const string Description = "description";
                  public const string CreatedAt = "created_at";
                  public const string ModifiedAt = "modified_at";
                  public const string UserId = "user_id";
               }
            }

            public static class Tag
            {
               public const string TableName = "tag";

               public static class Column
               {
                  public const string Id = "id";
                  public const string Value = "value";
               }
            }

            public static class NoteTag
            {
               public const string TableName = "note_tag";

               public static class Column
               {
                  public const string NoteId = "note_id";
                  public const string TagId = "tag_id";
               }
            }
         }
      }
   }
}