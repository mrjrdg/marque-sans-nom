using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class InitialDatabaseSeeding : Migration
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
                name: "Entreprise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepriseName = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    EntreprisePhone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entreprise_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AddressId = table.Column<int>(nullable: false),
                    EntrepriseId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Entreprise_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprise",
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
                    { "dd877ad9-bab2-42a4-ad24-b9d3cbd397db", "d255b2c0-20ac-4b82-acac-484a15accd03", "Admin", "ADMIN" },
                    { "642fc052-6ef4-46c8-94a8-8cbc4d58abf0", "70caf04b-3820-4cc7-a2a3-512d920c6ee9", "CustomerPeople", "CUSTOMERPEOPLE" },
                    { "d41d84ad-c113-4092-9714-3fb00153c109", "4a5d2b44-1016-4960-b4f1-c6ee9a77a965", "CustomerBusiness", "CUSTOMERBUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "424955bd-d31b-453e-9bf7-89b91dde0c9c", 0, "1323f696-0f4e-482a-a99c-d4c8da0743ce", "jordangauthier@noname.com", false, "Jordan", "Gauthier", false, null, "JORDANGAUTHIER@NONAME.COM", "JORDANGAUTHIER@NONAME.COM", "AQAAAAEAACcQAAAAEJQXe2oST0ds4DFEOmaXzFiCcaZXESdMQ84FHLwZRwf8zsWJusY+mxFP6mZ4C8De+w==", "514-979-7316", true, "b40f6a37-be16-4d1c-b221-465c590f1f91", false, "jordangauthier@noname.com" },
                    { "400919a5-8692-4bbc-88d3-f04e1f4ad2d3", 0, "26634460-4374-46e9-b625-2276f632582f", "alexdufour@noname.com", false, "Alex", "Dufour", false, null, "ALEXDUFOUR@NONAME.COM", "ALEXDUFOUR@NONAME.COM", "AQAAAAEAACcQAAAAEJQXe2oST0ds4DFEOmaXzFiCcaZXESdMQ84FHLwZRwf8zsWJusY+mxFP6mZ4C8De+w==", "514-911-9111", false, "6759718d-36d3-4853-be8a-dc4df849a71c", false, "alexdufour@noname.com" },
                    { "a0930ac9-a90d-48ac-85da-e9f4341e7de7", 0, "b8508197-2066-40e3-bfb5-dff02af52266", "alexhamel@noname.com", false, "Alexandre", "Hamel-Boudreault", false, null, "alexhamel@noname.com", "alexhamel@noname.com", "AQAAAAEAACcQAAAAEJQXe2oST0ds4DFEOmaXzFiCcaZXESdMQ84FHLwZRwf8zsWJusY+mxFP6mZ4C8De+w==", null, false, "3b3f7030-79a8-4b5f-814e-1bb992226d30", false, "alexhamel@noname.com" },
                    { "64fc62c0-110b-4b0e-b45c-22dd9f03f6bd", 0, "5e981c06-db38-42cc-b5ea-05b0296ea126", "philippesoucy@noname.com", false, "Philippe", "Soucy", false, null, "PHILIPPESOUCY@NONAME.COM", "PHILIPPESOUCY@NONAME.COM", "AQAAAAEAACcQAAAAEJQXe2oST0ds4DFEOmaXzFiCcaZXESdMQ84FHLwZRwf8zsWJusY+mxFP6mZ4C8De+w==", null, false, "18160938-2e8c-417d-a475-d0a102efcb91", false, "philippesoucy@noname.com" }
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
                    { "424955bd-d31b-453e-9bf7-89b91dde0c9c", "dd877ad9-bab2-42a4-ad24-b9d3cbd397db" },
                    { "400919a5-8692-4bbc-88d3-f04e1f4ad2d3", "dd877ad9-bab2-42a4-ad24-b9d3cbd397db" },
                    { "a0930ac9-a90d-48ac-85da-e9f4341e7de7", "dd877ad9-bab2-42a4-ad24-b9d3cbd397db" },
                    { "64fc62c0-110b-4b0e-b45c-22dd9f03f6bd", "dd877ad9-bab2-42a4-ad24-b9d3cbd397db" }
                });

            migrationBuilder.InsertData(
                table: "Entreprise",
                columns: new[] { "Id", "AddressId", "EntrepriseName", "EntreprisePhone" },
                values: new object[,]
                {
                    { 2, 1, "Groupe tazor", "(514) 911-9111" },
                    { 1, 3, "Pro gym", "(514) 252-8704" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "EndDate", "EntrepriseId", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[] { 2, 2, "400919a5-8692-4bbc-88d3-f04e1f4ad2d3", new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Souper spaghetti de dufour (Lever de fond)" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "EndDate", "EntrepriseId", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[] { 1, 3, "424955bd-d31b-453e-9bf7-89b91dde0c9c", new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Zumba de dufour" });

            migrationBuilder.InsertData(
                table: "EventApplicationUsers",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { "424955bd-d31b-453e-9bf7-89b91dde0c9c", 2 },
                    { "400919a5-8692-4bbc-88d3-f04e1f4ad2d3", 2 },
                    { "64fc62c0-110b-4b0e-b45c-22dd9f03f6bd", 2 },
                    { "a0930ac9-a90d-48ac-85da-e9f4341e7de7", 2 },
                    { "424955bd-d31b-453e-9bf7-89b91dde0c9c", 1 },
                    { "400919a5-8692-4bbc-88d3-f04e1f4ad2d3", 1 }
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
                name: "IX_Entreprise_AddressId",
                table: "Entreprise",
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
                name: "IX_Events_EntrepriseId",
                table: "Events",
                column: "EntrepriseId");

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
                name: "Entreprise");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
