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
                name: "Entreprise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepriseName = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
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
                    EntrepriseId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    { "04dada9c-cabc-45a6-bc0d-2514539de128", "5f912fad-721c-4b28-be67-d1702821de75", "Admin", "ADMIN" },
                    { "0250a755-7025-4002-bafe-d9103d49ef21", "81b8bc0b-7069-4daf-bcda-cb58bb894294", "CustomerPeople", "CUSTOMERPEOPLE" },
                    { "60194e0b-fa7c-40cc-8808-a33316405da2", "cf2c1c65-cce7-4c57-a530-ca8f007c8733", "CustomerBusiness", "CUSTOMERBUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d147d359-bbb7-4095-8e15-d217779deaa8", 0, "959747b0-7e01-425e-a51f-d06da96848a9", "jordangauthier@noname.com", false, "Jordan", "Gauthier", false, null, "JORDANGAUTHIER@NONAME.COM", "JORDANGAUTHIER@NONAME.COM", "AQAAAAEAACcQAAAAECS/nrGvsClwsoYYiag3bhLPKyvQyVpz/LGtQZy2+KqcRS8niz0rhReicqGt2GmFfQ==", "514-979-7316", true, "501c6583-c1d4-468e-ba67-a27514e0056e", false, "jordangauthier@noname.com" },
                    { "937d51c8-19f0-4219-9a9c-169c92bb1626", 0, "702fb545-a945-4a5f-97b5-c2009dc3c1d6", "alexdufour@noname.com", false, "Alex", "Dufour", false, null, "ALEXDUFOUR@NONAME.COM", "ALEXDUFOUR@NONAME.COM", "AQAAAAEAACcQAAAAECS/nrGvsClwsoYYiag3bhLPKyvQyVpz/LGtQZy2+KqcRS8niz0rhReicqGt2GmFfQ==", "514-911-9111", false, "adc557cc-c873-445c-b311-c4dce4dba731", false, "alexdufour@noname.com" },
                    { "f89ad1aa-4ae5-4f83-9083-b42ee060e187", 0, "dd381d4c-e32d-4e86-a192-d1d758cc5327", "alexhamel@noname.com", false, "Alexandre", "Hamel-Boudreault", false, null, "alexhamel@noname.com", "alexhamel@noname.com", "AQAAAAEAACcQAAAAECS/nrGvsClwsoYYiag3bhLPKyvQyVpz/LGtQZy2+KqcRS8niz0rhReicqGt2GmFfQ==", null, false, "e329c92e-489b-4cc0-a9dc-6da0856d4401", false, "alexhamel@noname.com" },
                    { "1bffcd9f-7256-45c0-8317-c2823c82a32f", 0, "909bc8f7-af55-4360-940b-f147761083a1", "philippesoucy@noname.com", false, "Philippe", "Soucy", false, null, "PHILIPPESOUCY@NONAME.COM", "PHILIPPESOUCY@NONAME.COM", "AQAAAAEAACcQAAAAECS/nrGvsClwsoYYiag3bhLPKyvQyVpz/LGtQZy2+KqcRS8niz0rhReicqGt2GmFfQ==", null, false, "23df3418-513c-4eae-a2c5-07b43d585e81", false, "philippesoucy@noname.com" }
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
                    { "d147d359-bbb7-4095-8e15-d217779deaa8", "04dada9c-cabc-45a6-bc0d-2514539de128" },
                    { "937d51c8-19f0-4219-9a9c-169c92bb1626", "04dada9c-cabc-45a6-bc0d-2514539de128" },
                    { "f89ad1aa-4ae5-4f83-9083-b42ee060e187", "04dada9c-cabc-45a6-bc0d-2514539de128" },
                    { "1bffcd9f-7256-45c0-8317-c2823c82a32f", "04dada9c-cabc-45a6-bc0d-2514539de128" }
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
                values: new object[] { 2, 2, "937d51c8-19f0-4219-9a9c-169c92bb1626", new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Souper spaghetti de dufour (Lever de fond)" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "EndDate", "EntrepriseId", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[] { 1, 3, "d147d359-bbb7-4095-8e15-d217779deaa8", new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Zumba de dufour" });

            migrationBuilder.InsertData(
                table: "EventApplicationUsers",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { "d147d359-bbb7-4095-8e15-d217779deaa8", 2 },
                    { "937d51c8-19f0-4219-9a9c-169c92bb1626", 2 },
                    { "1bffcd9f-7256-45c0-8317-c2823c82a32f", 2 },
                    { "f89ad1aa-4ae5-4f83-9083-b42ee060e187", 2 },
                    { "d147d359-bbb7-4095-8e15-d217779deaa8", 1 },
                    { "937d51c8-19f0-4219-9a9c-169c92bb1626", 1 }
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
