using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class init : Migration
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
                    { "37cbe6f2-a58d-4cfd-aa5d-271854ddd16f", "bff25604-4394-4fa2-9b56-d7ee9b63cf02", "Admin", "ADMIN" },
                    { "0ec768ac-c74a-4e90-9151-3255be541a13", "9791f130-7c0d-4bd3-ad95-97a3996eeba2", "CustomerPeople", "CUSTOMERPEOPLE" },
                    { "b42db1bb-c8d0-4e82-a1d7-1260ca8ce997", "60da1bd1-4082-4d99-9c14-6aa672c2035e", "CustomerBusiness", "CUSTOMERBUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "15f23768-0fab-4623-b13e-5de26db78808", 0, "9d2f3c22-0756-4fc7-bc59-f920297403e3", "jordangauthier@noname.com", false, "Jordan", "Gauthier", false, null, "JORDANGAUTHIER@NONAME.COM", "JORDANGAUTHIER@NONAME.COM", "AQAAAAEAACcQAAAAEBlNIHfXcbVELPrWd9N+ftBY5qr6zlcJBI5L/gcofokeWPrRXR+qjlQe6xzVrZB9WQ==", "514-979-7316", true, "89dcaee9-766c-44af-916a-fd61a5123806", false, "jordangauthier@noname.com" },
                    { "77cc5faf-657b-4410-ba03-689faa1bc0a6", 0, "719c1dd9-57be-49ad-9749-b18478912658", "alexdufour@noname.com", false, "Alex", "Dufour", false, null, "ALEXDUFOUR@NONAME.COM", "ALEXDUFOUR@NONAME.COM", "AQAAAAEAACcQAAAAEBlNIHfXcbVELPrWd9N+ftBY5qr6zlcJBI5L/gcofokeWPrRXR+qjlQe6xzVrZB9WQ==", "514-911-9111", false, "0c309607-572c-4a34-a3a4-5cd5e7a179f5", false, "alexdufour@noname.com" },
                    { "ada2b96c-3a54-45a9-8962-80ed922cf38e", 0, "b3586ff4-e590-4854-9430-c1ff64cd3e1b", "alexhamel@noname.com", false, "Alexandre", "Hamel-Boudreault", false, null, "alexhamel@noname.com", "alexhamel@noname.com", "AQAAAAEAACcQAAAAEBlNIHfXcbVELPrWd9N+ftBY5qr6zlcJBI5L/gcofokeWPrRXR+qjlQe6xzVrZB9WQ==", null, false, "48a93ede-d50c-4694-8b54-e8b08859ced4", false, "alexhamel@noname.com" },
                    { "fcd25c82-16b2-49ee-a666-04755ba34a4b", 0, "f0f11a18-2d50-450b-a4c9-9b4378b543b9", "philippesoucy@noname.com", false, "Philippe", "Soucy", false, null, "PHILIPPESOUCY@NONAME.COM", "PHILIPPESOUCY@NONAME.COM", "AQAAAAEAACcQAAAAEBlNIHfXcbVELPrWd9N+ftBY5qr6zlcJBI5L/gcofokeWPrRXR+qjlQe6xzVrZB9WQ==", null, false, "921ca609-3f21-4a75-ba71-13c81832713f", false, "philippesoucy@noname.com" }
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
                    { "15f23768-0fab-4623-b13e-5de26db78808", "37cbe6f2-a58d-4cfd-aa5d-271854ddd16f" },
                    { "77cc5faf-657b-4410-ba03-689faa1bc0a6", "37cbe6f2-a58d-4cfd-aa5d-271854ddd16f" },
                    { "ada2b96c-3a54-45a9-8962-80ed922cf38e", "37cbe6f2-a58d-4cfd-aa5d-271854ddd16f" },
                    { "fcd25c82-16b2-49ee-a666-04755ba34a4b", "37cbe6f2-a58d-4cfd-aa5d-271854ddd16f" }
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
                values: new object[] { 2, 2, "77cc5faf-657b-4410-ba03-689faa1bc0a6", 2, new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Souper spaghetti de dufour (Lever de fond)" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "BusinessId", "EndDate", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[] { 1, 3, "15f23768-0fab-4623-b13e-5de26db78808", 1, new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Zumba de dufour" });

            migrationBuilder.InsertData(
                table: "EventApplicationUsers",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { "15f23768-0fab-4623-b13e-5de26db78808", 2 },
                    { "77cc5faf-657b-4410-ba03-689faa1bc0a6", 2 },
                    { "fcd25c82-16b2-49ee-a666-04755ba34a4b", 2 },
                    { "ada2b96c-3a54-45a9-8962-80ed922cf38e", 2 },
                    { "15f23768-0fab-4623-b13e-5de26db78808", 1 },
                    { "77cc5faf-657b-4410-ba03-689faa1bc0a6", 1 }
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
