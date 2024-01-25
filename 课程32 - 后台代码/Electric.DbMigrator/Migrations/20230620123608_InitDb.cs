using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Electric.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EleAuditLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "API接口地址"),
                    Method = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "接口的方法"),
                    Parameters = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "参数"),
                    ReturnValue = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "返回结果"),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false, comment: "执行时间"),
                    ClientIpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "客户端IP"),
                    BrowserInfo = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "浏览器信息"),
                    AuditLogType = table.Column<int>(type: "int", nullable: false, comment: "日志类型 0:正常日志记录，99：异常日志"),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "异常信息"),
                    Exception = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "详细异常"),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "创建者Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "最后编辑时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleAuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElePermission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "权限名称"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "权限编码"),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Url地址"),
                    Component = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Vue页面组件"),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "图标"),
                    PermissionType = table.Column<int>(type: "int", nullable: false, comment: "菜单类型,0：菜单权限、元素权限、Api权限、数据权限"),
                    ApiMethod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "API方法：GET、PUT、POST、DELETE"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    ParentId = table.Column<long>(type: "bigint", nullable: false, comment: "父菜单Id"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态，0：禁用，1：正常"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "创建者Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "最后编辑时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElePermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EleRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "创建者Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "最后编辑时间"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "状态，0：禁用，1：正常"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EleUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "创建者Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "最后编辑时间"),
                    FullName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EleRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EleRoleClaim_EleRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EleRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleRolePermission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false, comment: "创建者Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "最后编辑时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EleRolePermission_ElePermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "ElePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleRolePermission_EleRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EleRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EleUserClaim_EleUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_EleUserLogin_EleUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleUserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EleUserRole_EleRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EleRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleUserRole_EleUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleUserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_EleUserToken_EleUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ElePermission",
                columns: new[] { "Id", "ApiMethod", "Code", "Component", "CreationTime", "CreatorId", "Icon", "LastModificationTime", "Name", "ParentId", "PermissionType", "Remark", "Sort", "Status", "Url" },
                values: new object[,]
                {
                    { 1L, "", "system", "", new DateTime(2023, 6, 20, 20, 36, 8, 39, DateTimeKind.Local).AddTicks(9983), 0L, "el-icon-s-tools", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "系统管理", 0L, 0, null, 0, 1, "system" },
                    { 2L, "", "system.user", "views/documentation/index", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(7), 0L, "el-icon-user-solid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "用户管理", 1L, 0, null, 0, 1, "system.user" },
                    { 3L, "", "system.role", "views/documentation/index", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(11), 0L, "peoples", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "角色管理", 1L, 0, null, 0, 1, "role" },
                    { 4L, "", "system.permission", "views/documentation/index", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(16), 0L, "list", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "菜单管理", 1L, 0, null, 0, 1, "permission" },
                    { 5L, "", "system.rolepermission", "views/documentation/index", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(19), 0L, "example", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "角色权限", 1L, 0, null, 0, 1, "rolepermission" },
                    { 6L, "", "system.user.add", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(38), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "添加", 2L, 1, null, 0, 1, "" },
                    { 7L, "", "system.user.edit", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(42), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "编辑", 2L, 1, null, 0, 1, "" },
                    { 8L, "", "system.user.delete", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(45), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "删除", 2L, 1, null, 0, 1, "" },
                    { 9L, "", "system.role.add", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(50), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "添加", 3L, 1, null, 0, 1, "" },
                    { 10L, "", "system.role.edit", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(53), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "编辑", 3L, 1, null, 0, 1, "" },
                    { 11L, "", "system.role.delete", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(56), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "删除", 3L, 1, null, 0, 1, "" },
                    { 12L, "", "system.permission.add", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(59), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "添加", 4L, 1, null, 0, 1, "" },
                    { 13L, "", "system.permission.edit", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(62), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "编辑", 4L, 1, null, 0, 1, "" },
                    { 14L, "", "system.permission.delete", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(66), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "删除", 4L, 1, null, 0, 1, "" },
                    { 15L, "", "system.rolepermission.update", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(69), 0L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "更新", 5L, 1, null, 0, 1, "" },
                    { 16L, "", "log.auditlog", "", new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(35), 0L, "bug", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "日志管理", 0L, 0, null, 0, 1, "log" }
                });

            migrationBuilder.InsertData(
                table: "EleRole",
                columns: new[] { "Id", "ConcurrencyStamp", "CreationTime", "CreatorId", "LastModificationTime", "Name", "NormalizedName", "Remark", "Status" },
                values: new object[] { 1L, null, new DateTime(2023, 6, 20, 20, 36, 7, 884, DateTimeKind.Local).AddTicks(6143), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "管理员", "管理员", null, 1 });

            migrationBuilder.InsertData(
                table: "EleUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationTime", "CreatorId", "Email", "EmailConfirmed", "FullName", "LastModificationTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Remark", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, "711b70d6-8e2d-4598-b448-5d8eb3e52624", new DateTime(2023, 6, 20, 20, 36, 7, 884, DateTimeKind.Local).AddTicks(6613), 0L, "admin@eletric.com", true, "管理员", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "ADMIN@ELETRIC.COM", "ADMIN", "AQAAAAIAAYagAAAAENzHi+4xk8kwsN6WlxiuImO4HLqFXA5QEHWaFPQ2UM0MVMp4lTCvv4DRZl90DmY/0Q==", "123456789", false, null, "abc", 1, false, "admin" });

            migrationBuilder.InsertData(
                table: "EleRolePermission",
                columns: new[] { "Id", "CreationTime", "CreatorId", "LastModificationTime", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(133), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L },
                    { 2L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(139), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L },
                    { 3L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(141), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L },
                    { 4L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(142), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L },
                    { 5L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(143), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 1L },
                    { 6L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(148), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 1L },
                    { 7L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(149), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, 1L },
                    { 8L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(151), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, 1L },
                    { 9L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(153), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, 1L },
                    { 10L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(154), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, 1L },
                    { 11L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(156), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11L, 1L },
                    { 12L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(157), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, 1L },
                    { 13L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(158), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, 1L },
                    { 14L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(159), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 1L },
                    { 15L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(160), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 1L },
                    { 16L, new DateTime(2023, 6, 20, 20, 36, 8, 40, DateTimeKind.Local).AddTicks(147), 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16L, 1L }
                });

            migrationBuilder.InsertData(
                table: "EleUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_EleAuditLog_AuditLogType",
                table: "EleAuditLog",
                column: "AuditLogType");

            migrationBuilder.CreateIndex(
                name: "IX_ElePermission_Code",
                table: "ElePermission",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElePermission_ParentId",
                table: "ElePermission",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ElePermission_Sort",
                table: "ElePermission",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "EleRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EleRoleClaim_RoleId",
                table: "EleRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EleRolePermission_PermissionId",
                table: "EleRolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_EleRolePermission_RoleId",
                table: "EleRolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "EleUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "EleUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EleUserClaim_UserId",
                table: "EleUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EleUserLogin_UserId",
                table: "EleUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EleUserRole_RoleId",
                table: "EleUserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EleAuditLog");

            migrationBuilder.DropTable(
                name: "EleRoleClaim");

            migrationBuilder.DropTable(
                name: "EleRolePermission");

            migrationBuilder.DropTable(
                name: "EleUserClaim");

            migrationBuilder.DropTable(
                name: "EleUserLogin");

            migrationBuilder.DropTable(
                name: "EleUserRole");

            migrationBuilder.DropTable(
                name: "EleUserToken");

            migrationBuilder.DropTable(
                name: "ElePermission");

            migrationBuilder.DropTable(
                name: "EleRole");

            migrationBuilder.DropTable(
                name: "EleUser");
        }
    }
}
