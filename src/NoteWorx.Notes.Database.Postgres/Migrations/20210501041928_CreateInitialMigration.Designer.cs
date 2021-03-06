﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteWorx.Notes.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NoteWorx.Notes.Database.Postgres.Migrations
{
    [DbContext(typeof(NoteWorxDbContext))]
    [Migration("20210501041928_CreateInitialMigration")]
    partial class CreateInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_identitydata_approle_id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("uix_identitydata_approle_normalizedname");

                    b.ToTable("app_role", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_identitydata_approleclaim_id");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_identitydata_approleclaim_roleid");

                    b.ToTable("app_role_claim", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_username");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_identitydata_appuser_id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("ix_identitydata_appuser_normalizedemail");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("uix_identitydata_appuser_normalizedusername");

                    b.ToTable("app_user", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_identitydata_appuserclaim_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identitydata_appuserclaim_userid");

                    b.HasIndex("UserId1");

                    b.ToTable("app_user_claim", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_identitydata_appuserlogin_loginproviderkey");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identitydata_appuserlogin_userid");

                    b.ToTable("app_user_login", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_identitydata_appuserrole_useridroleid");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_identitydata_appuserrole_roleid");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identitydata_appuserrole_userid");

                    b.ToTable("app_user_role", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_identitydata_appusertoken_loginproviderkey");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identitydata_appusertoken_userid");

                    b.ToTable("app_user_token", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expires_at");

                    b.Property<DateTime?>("RevokedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("revoked_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_identitydata_refreshtoken_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_identitydata_refreshtoken_userid");

                    b.ToTable("refresh_token", "identity_data");
                });

            modelBuilder.Entity("NoteWorx.Notes.Data.Models.Note", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_notedata_note_id");

                    b.HasIndex("UserId");

                    b.ToTable("note", "note_data");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppRoleClaim", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_identitydata_approleclaim_roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserClaim", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_identitydata_appuser_claimid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserLogin", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_identitydata_appuserlogin_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserRole", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_identitydata_appuserrole_roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_identitydata_appuserrole_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUserToken", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_identitydata_appusertoken_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.RefreshToken", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_identitydata_refreshtoken_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteWorx.Notes.Data.Models.Note", b =>
                {
                    b.HasOne("NoteWorx.Identity.Data.Models.AppUser", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppRole", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("NoteWorx.Identity.Data.Models.AppUser", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Notes");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Tokens");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
