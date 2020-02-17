using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: false),
                    CivicNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    AppartmentNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    PriceToPayToParticipate = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventApplicationUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventApplicationUsers", x => new { x.ApplicationUserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventApplicationUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventApplicationUsers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AppartmentNumber", "City", "CivicNumber", "Country", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, null, "Terrebonne", 2502, "Canada", "J6X 0A5", "QC", "Des jacinthes" },
                    { 2, 2, "Montreal", 2265, "Canada", "H1V 2E6", "QC", "Boulevard PIE-IX" },
                    { 3, null, "Montreal", 4500, "Canada", "H1V 3N8", "QC", "Hochelaga" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba1931c9-5934-43f2-a814-0f380103fd65", "c91aab51-0420-45c0-a245-fad2d7c5fac5", "Admin", "ADMIN" },
                    { "ecc43d7d-a14e-4884-813d-8c68dca18d33", "b8cffd0a-0dd9-4c6a-940a-a0c8cc673949", "CustomerPeople", "CUSTOMERPEOPLE" },
                    { "296a0b44-495e-4f41-8da6-7b251eaef8a3", "b2ea00d1-b29f-4132-935d-970fdeefced5", "CustomerBusiness", "CUSTOMERBUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a72a0a93-794d-4fb1-9bd8-1260e7dbc1cc", 0, "93454c53-65d5-47e8-bd86-7d6219b43b77", "jordangauthier@noname.com", false, "Jordan", "Gauthier", false, null, "JORDANGAUTHIER@NONAME.COM", "JORDANGAUTHIER@NONAME.COM", "AQAAAAEAACcQAAAAEArnPirBKDxLSqE4oQagIKj4qBrlUpaKknr1uiGhe/9UAc+FlXKchjBcKTemdok4jw==", "514-979-7316", true, "855942d6-1f80-4dd0-9e6c-ee5a21c5b0cc", false, "jordangauthier@noname.com" },
                    { "e0cb1836-0067-4d2e-af69-8ac0eccbf8a1", 0, "fb1e1f1c-b604-447f-8b54-9f01e81285aa", "alexdufour@noname.com", false, "Alex", "Dufour", false, null, "ALEXDUFOUR@NONAME.COM", "ALEXDUFOUR@NONAME.COM", "AQAAAAEAACcQAAAAEArnPirBKDxLSqE4oQagIKj4qBrlUpaKknr1uiGhe/9UAc+FlXKchjBcKTemdok4jw==", "514-911-9111", false, "34672cfb-7e8c-4cc7-937a-6ce6bfe988ed", false, "alexdufour@noname.com" },
                    { "6070951d-3c77-4577-9ad3-aa0ddf1e5c18", 0, "61f90150-3e61-4785-b6fc-76179fb54e9d", "alexhamel@noname.com", false, "Alexandre", "Hamel-Boudreault", false, null, "alexhamel@noname.com", "alexhamel@noname.com", "AQAAAAEAACcQAAAAEArnPirBKDxLSqE4oQagIKj4qBrlUpaKknr1uiGhe/9UAc+FlXKchjBcKTemdok4jw==", null, false, "c841027b-6eac-4b9b-901b-bc3e91748fac", false, "alexhamel@noname.com" },
                    { "6b958624-5f31-49b7-8806-9f6ecaf385b7", 0, "7670bc00-4308-4036-be23-0f157ccd41e6", "philippesoucy@noname.com", false, "Philippe", "Soucy", false, null, "PHILIPPESOUCY@NONAME.COM", "PHILIPPESOUCY@NONAME.COM", "AQAAAAEAACcQAAAAEArnPirBKDxLSqE4oQagIKj4qBrlUpaKknr1uiGhe/9UAc+FlXKchjBcKTemdok4jw==", null, false, "b198a15a-9e4c-426f-bb17-2d6fc8d11b1b", false, "philippesoucy@noname.com" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Entrainement" },
                    { 2, "Lever de fond" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "a72a0a93-794d-4fb1-9bd8-1260e7dbc1cc", "ba1931c9-5934-43f2-a814-0f380103fd65" },
                    { "e0cb1836-0067-4d2e-af69-8ac0eccbf8a1", "ba1931c9-5934-43f2-a814-0f380103fd65" },
                    { "6070951d-3c77-4577-9ad3-aa0ddf1e5c18", "ba1931c9-5934-43f2-a814-0f380103fd65" },
                    { "6b958624-5f31-49b7-8806-9f6ecaf385b7", "ba1931c9-5934-43f2-a814-0f380103fd65" }
                });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "AddressId", "Name", "Phone" },
                values: new object[,]
                {
                    { 2, 1, "Groupe tazor", "(514) 911-9111" },
                    { 1, 3, "Pro gym", "(514) 252-8704" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "BusinessId", "EndDate", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[] { 2, 2, "e0cb1836-0067-4d2e-af69-8ac0eccbf8a1", 2, new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Souper spaghetti de dufour (Lever de fond)" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "BusinessId", "EndDate", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[] { 1, 3, "a72a0a93-794d-4fb1-9bd8-1260e7dbc1cc", 1, new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Zumba de dufour" });

            migrationBuilder.InsertData(
                table: "EventApplicationUsers",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { "a72a0a93-794d-4fb1-9bd8-1260e7dbc1cc", 2 },
                    { "e0cb1836-0067-4d2e-af69-8ac0eccbf8a1", 2 },
                    { "6b958624-5f31-49b7-8806-9f6ecaf385b7", 2 },
                    { "6070951d-3c77-4577-9ad3-aa0ddf1e5c18", 2 },
                    { "a72a0a93-794d-4fb1-9bd8-1260e7dbc1cc", 1 },
                    { "e0cb1836-0067-4d2e-af69-8ac0eccbf8a1", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_AddressId",
                table: "Businesses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EventApplicationUsers_EventId",
                table: "EventApplicationUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AddressId",
                table: "Events",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_BusinessId",
                table: "Events",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EventApplicationUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
