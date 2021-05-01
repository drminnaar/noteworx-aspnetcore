using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NoteWorx.Notes.Database.Postgres.Migrations
{
    public partial class CreateInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity_data");

            migrationBuilder.EnsureSchema(
                name: "note_data");

            migrationBuilder.CreateTable(
                name: "app_role",
                schema: "identity_data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_approle_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_user",
                schema: "identity_data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_appuser_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_role_claim",
                schema: "identity_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_approleclaim_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_identitydata_approleclaim_roleid",
                        column: x => x.role_id,
                        principalSchema: "identity_data",
                        principalTable: "app_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_user_claim",
                schema: "identity_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_appuserclaim_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_app_user_claim_app_user_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_identitydata_appuser_claimid",
                        column: x => x.user_id,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_user_login",
                schema: "identity_data",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_appuserlogin_loginproviderkey", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_identitydata_appuserlogin_userid",
                        column: x => x.user_id,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_user_role",
                schema: "identity_data",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_appuserrole_useridroleid", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_identitydata_appuserrole_roleid",
                        column: x => x.role_id,
                        principalSchema: "identity_data",
                        principalTable: "app_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_identitydata_appuserrole_userid",
                        column: x => x.user_id,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_user_token",
                schema: "identity_data",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_appusertoken_loginproviderkey", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_identitydata_appusertoken_userid",
                        column: x => x.user_id,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "note",
                schema: "note_data",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    tags = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notedata_note_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_note_app_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                schema: "identity_data",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    revoked_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identitydata_refreshtoken_id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_identitydata_refreshtoken_userid",
                        column: x => x.UserId,
                        principalSchema: "identity_data",
                        principalTable: "app_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "uix_identitydata_approle_normalizedname",
                schema: "identity_data",
                table: "app_role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_approleclaim_roleid",
                schema: "identity_data",
                table: "app_role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_appuser_normalizedemail",
                schema: "identity_data",
                table: "app_user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "uix_identitydata_appuser_normalizedusername",
                schema: "identity_data",
                table: "app_user",
                column: "normalized_username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_app_user_claim_UserId1",
                schema: "identity_data",
                table: "app_user_claim",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_appuserclaim_userid",
                schema: "identity_data",
                table: "app_user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_appuserlogin_userid",
                schema: "identity_data",
                table: "app_user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_appuserrole_roleid",
                schema: "identity_data",
                table: "app_user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_appuserrole_userid",
                schema: "identity_data",
                table: "app_user_role",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_appusertoken_userid",
                schema: "identity_data",
                table: "app_user_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_note_user_id",
                schema: "note_data",
                table: "note",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identitydata_refreshtoken_userid",
                schema: "identity_data",
                table: "refresh_token",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_role_claim",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "app_user_claim",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "app_user_login",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "app_user_role",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "app_user_token",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "note",
                schema: "note_data");

            migrationBuilder.DropTable(
                name: "refresh_token",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "app_role",
                schema: "identity_data");

            migrationBuilder.DropTable(
                name: "app_user",
                schema: "identity_data");
        }
    }
}
