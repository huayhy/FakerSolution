using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Faker.Solution.Migrations
{
    public partial class AbpZero_SqlServer_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faker_AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 256, nullable: true),
                    Parameters = table.Column<string>(maxLength: 1024, nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Exception = table.Column<string>(maxLength: 2000, nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_BackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    JobType = table.Column<string>(maxLength: 512, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false),
                    Priority = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_BackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_DynamicParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_DynamicParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Editions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_EntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_EntityChangeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_LanguageTexts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    LanguageName = table.Column<string>(maxLength: 128, nullable: false),
                    Source = table.Column<string>(maxLength: 128, nullable: false),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 67108864, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_LanguageTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false),
                    UserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    TenantIds = table.Column<string>(maxLength: 131072, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_NotificationSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_NotificationSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_OrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_OrganizationUnitRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_OrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_OrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_OrganizationUnits_Faker_OrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Faker_OrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faker_TenantNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_TenantNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserLinkId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Result = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserLoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantNotificationId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserOrganizationUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AuthenticationSource = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    EmailConfirmationCode = table.Column<string>(maxLength: 328, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 328, nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsLockoutEnabled = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_Users_Faker_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Users_Faker_Users_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Users_Faker_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faker_WebhookEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookName = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_WebhookEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_WebhookSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    WebhookUri = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Webhooks = table.Column<string>(nullable: true),
                    Headers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_WebhookSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faker_DynamicParameterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    DynamicParameterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_DynamicParameterValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_DynamicParameterValues_Faker_DynamicParameters_DynamicParameterId",
                        column: x => x.DynamicParameterId,
                        principalTable: "Faker_DynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_EntityDynamicParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityFullName = table.Column<string>(nullable: true),
                    DynamicParameterId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_EntityDynamicParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_EntityDynamicParameters_Faker_DynamicParameters_DynamicParameterId",
                        column: x => x.DynamicParameterId,
                        principalTable: "Faker_DynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Features",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_Features_Faker_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Faker_Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_EntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_EntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_EntityChanges_Faker_EntityChangeSets_EntityChangeSetId",
                        column: x => x.EntityChangeSetId,
                        principalTable: "Faker_EntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_Roles_Faker_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Roles_Faker_Users_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Roles_Faker_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_Settings_Faker_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ConnectionString = table.Column<string>(maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_Tenants_Faker_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Tenants_Faker_Users_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Tenants_Faker_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Faker_Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faker_Tenants_Faker_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_UserClaims_Faker_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_UserLogins_Faker_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_UserRoles_Faker_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_UserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_UserTokens_Faker_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_WebhookSendAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookEventId = table.Column<Guid>(nullable: false),
                    WebhookSubscriptionId = table.Column<Guid>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    ResponseStatusCode = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_WebhookSendAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_WebhookSendAttempts_Faker_WebhookEvents_WebhookEventId",
                        column: x => x.WebhookEventId,
                        principalTable: "Faker_WebhookEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_EntityDynamicParameterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    EntityDynamicParameterId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_EntityDynamicParameterValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_EntityDynamicParameterValues_Faker_EntityDynamicParameters_EntityDynamicParameterId",
                        column: x => x.EntityDynamicParameterId,
                        principalTable: "Faker_EntityDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_EntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_EntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_EntityPropertyChanges_Faker_EntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "Faker_EntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsGranted = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_Permissions_Faker_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Faker_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faker_Permissions_Faker_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Faker_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faker_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faker_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faker_RoleClaims_Faker_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Faker_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_AuditLogs_TenantId_ExecutionDuration",
                table: "Faker_AuditLogs",
                columns: new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_AuditLogs_TenantId_ExecutionTime",
                table: "Faker_AuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_AuditLogs_TenantId_UserId",
                table: "Faker_AuditLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_BackgroundJobs_IsAbandoned_NextTryTime",
                table: "Faker_BackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_DynamicParameters_ParameterName_TenantId",
                table: "Faker_DynamicParameters",
                columns: new[] { "ParameterName", "TenantId" },
                unique: true,
                filter: "[ParameterName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_DynamicParameterValues_DynamicParameterId",
                table: "Faker_DynamicParameterValues",
                column: "DynamicParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityChanges_EntityChangeSetId",
                table: "Faker_EntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityChanges_EntityTypeFullName_EntityId",
                table: "Faker_EntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityChangeSets_TenantId_CreationTime",
                table: "Faker_EntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityChangeSets_TenantId_Reason",
                table: "Faker_EntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityChangeSets_TenantId_UserId",
                table: "Faker_EntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityDynamicParameters_DynamicParameterId",
                table: "Faker_EntityDynamicParameters",
                column: "DynamicParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityDynamicParameters_EntityFullName_DynamicParameterId_TenantId",
                table: "Faker_EntityDynamicParameters",
                columns: new[] { "EntityFullName", "DynamicParameterId", "TenantId" },
                unique: true,
                filter: "[EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityDynamicParameterValues_EntityDynamicParameterId",
                table: "Faker_EntityDynamicParameterValues",
                column: "EntityDynamicParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_EntityPropertyChanges_EntityChangeId",
                table: "Faker_EntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Features_EditionId_Name",
                table: "Faker_Features",
                columns: new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Features_TenantId_Name",
                table: "Faker_Features",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Languages_TenantId_Name",
                table: "Faker_Languages",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_LanguageTexts_TenantId_Source_LanguageName_Key",
                table: "Faker_LanguageTexts",
                columns: new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_NotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId",
                table: "Faker_NotificationSubscriptions",
                columns: new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_NotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId",
                table: "Faker_NotificationSubscriptions",
                columns: new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_OrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "Faker_OrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_OrganizationUnitRoles_TenantId_RoleId",
                table: "Faker_OrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_OrganizationUnits_ParentId",
                table: "Faker_OrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_OrganizationUnits_TenantId_Code",
                table: "Faker_OrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Permissions_TenantId_Name",
                table: "Faker_Permissions",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Permissions_RoleId",
                table: "Faker_Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Permissions_UserId",
                table: "Faker_Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_RoleClaims_RoleId",
                table: "Faker_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_RoleClaims_TenantId_ClaimType",
                table: "Faker_RoleClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Roles_CreatorUserId",
                table: "Faker_Roles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Roles_DeleterUserId",
                table: "Faker_Roles",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Roles_LastModifierUserId",
                table: "Faker_Roles",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Roles_TenantId_NormalizedName",
                table: "Faker_Roles",
                columns: new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Settings_UserId",
                table: "Faker_Settings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Settings_TenantId_Name_UserId",
                table: "Faker_Settings",
                columns: new[] { "TenantId", "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faker_TenantNotifications_TenantId",
                table: "Faker_TenantNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Tenants_CreatorUserId",
                table: "Faker_Tenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Tenants_DeleterUserId",
                table: "Faker_Tenants",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Tenants_EditionId",
                table: "Faker_Tenants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Tenants_LastModifierUserId",
                table: "Faker_Tenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Tenants_TenancyName",
                table: "Faker_Tenants",
                column: "TenancyName");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserAccounts_EmailAddress",
                table: "Faker_UserAccounts",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserAccounts_UserName",
                table: "Faker_UserAccounts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserAccounts_TenantId_EmailAddress",
                table: "Faker_UserAccounts",
                columns: new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserAccounts_TenantId_UserId",
                table: "Faker_UserAccounts",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserAccounts_TenantId_UserName",
                table: "Faker_UserAccounts",
                columns: new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserClaims_UserId",
                table: "Faker_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserClaims_TenantId_ClaimType",
                table: "Faker_UserClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserLoginAttempts_UserId_TenantId",
                table: "Faker_UserLoginAttempts",
                columns: new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result",
                table: "Faker_UserLoginAttempts",
                columns: new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserLogins_UserId",
                table: "Faker_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserLogins_TenantId_UserId",
                table: "Faker_UserLogins",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserLogins_TenantId_LoginProvider_ProviderKey",
                table: "Faker_UserLogins",
                columns: new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserNotifications_UserId_State_CreationTime",
                table: "Faker_UserNotifications",
                columns: new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserOrganizationUnits_TenantId_OrganizationUnitId",
                table: "Faker_UserOrganizationUnits",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserOrganizationUnits_TenantId_UserId",
                table: "Faker_UserOrganizationUnits",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserRoles_UserId",
                table: "Faker_UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserRoles_TenantId_RoleId",
                table: "Faker_UserRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserRoles_TenantId_UserId",
                table: "Faker_UserRoles",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Users_CreatorUserId",
                table: "Faker_Users",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Users_DeleterUserId",
                table: "Faker_Users",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Users_LastModifierUserId",
                table: "Faker_Users",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Users_TenantId_NormalizedEmailAddress",
                table: "Faker_Users",
                columns: new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_Users_TenantId_NormalizedUserName",
                table: "Faker_Users",
                columns: new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserTokens_UserId",
                table: "Faker_UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faker_UserTokens_TenantId_UserId",
                table: "Faker_UserTokens",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Faker_WebhookSendAttempts_WebhookEventId",
                table: "Faker_WebhookSendAttempts",
                column: "WebhookEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faker_AuditLogs");

            migrationBuilder.DropTable(
                name: "Faker_BackgroundJobs");

            migrationBuilder.DropTable(
                name: "Faker_DynamicParameterValues");

            migrationBuilder.DropTable(
                name: "Faker_EntityDynamicParameterValues");

            migrationBuilder.DropTable(
                name: "Faker_EntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "Faker_Features");

            migrationBuilder.DropTable(
                name: "Faker_Languages");

            migrationBuilder.DropTable(
                name: "Faker_LanguageTexts");

            migrationBuilder.DropTable(
                name: "Faker_Notifications");

            migrationBuilder.DropTable(
                name: "Faker_NotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "Faker_OrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "Faker_OrganizationUnits");

            migrationBuilder.DropTable(
                name: "Faker_Permissions");

            migrationBuilder.DropTable(
                name: "Faker_RoleClaims");

            migrationBuilder.DropTable(
                name: "Faker_Settings");

            migrationBuilder.DropTable(
                name: "Faker_TenantNotifications");

            migrationBuilder.DropTable(
                name: "Faker_Tenants");

            migrationBuilder.DropTable(
                name: "Faker_UserAccounts");

            migrationBuilder.DropTable(
                name: "Faker_UserClaims");

            migrationBuilder.DropTable(
                name: "Faker_UserLoginAttempts");

            migrationBuilder.DropTable(
                name: "Faker_UserLogins");

            migrationBuilder.DropTable(
                name: "Faker_UserNotifications");

            migrationBuilder.DropTable(
                name: "Faker_UserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "Faker_UserRoles");

            migrationBuilder.DropTable(
                name: "Faker_UserTokens");

            migrationBuilder.DropTable(
                name: "Faker_WebhookSendAttempts");

            migrationBuilder.DropTable(
                name: "Faker_WebhookSubscriptions");

            migrationBuilder.DropTable(
                name: "Faker_EntityDynamicParameters");

            migrationBuilder.DropTable(
                name: "Faker_EntityChanges");

            migrationBuilder.DropTable(
                name: "Faker_Roles");

            migrationBuilder.DropTable(
                name: "Faker_Editions");

            migrationBuilder.DropTable(
                name: "Faker_WebhookEvents");

            migrationBuilder.DropTable(
                name: "Faker_DynamicParameters");

            migrationBuilder.DropTable(
                name: "Faker_EntityChangeSets");

            migrationBuilder.DropTable(
                name: "Faker_Users");
        }
    }
}
