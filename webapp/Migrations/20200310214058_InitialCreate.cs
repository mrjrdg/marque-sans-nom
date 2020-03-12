using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "MessageConversations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: false),
                    SenderId = table.Column<string>(nullable: false),
                    ReceiverId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageConversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageConversations_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageConversations_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    MessageConversationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_MessageConversations_MessageConversationId",
                        column: x => x.MessageConversationId,
                        principalTable: "MessageConversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "ee77b2eb-c623-4e2f-a16b-eeebb3744774", "437f3e25-0ba3-4ea3-970a-33414f0064ac", "Admin", "ADMIN" },
                    { "88a36f70-99e6-4cef-8c72-e92d5536de1b", "0b60ac8e-06ec-4702-866c-df145f2b04bb", "CustomerPeople", "CUSTOMERPEOPLE" },
                    { "96ceeed8-22de-426d-8cf6-a42ff20ed220", "99f8a9dc-b2f6-4370-a99a-332ca0ff6c59", "CustomerBusiness", "CUSTOMERBUSINESS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14ad00d3-6ab5-49df-b269-44cde5f29e3e", 0, "5de37be1-90bd-4a8f-8fc4-96b95c21fa00", "jordangauthier@noname.com", false, "Jordan", "Gauthier", false, null, "JORDANGAUTHIER@NONAME.COM", "JORDANGAUTHIER@NONAME.COM", "AQAAAAEAACcQAAAAEJkpl6Zqtod+CrD298Kyfxks25FB6VVhLXpBMi+4eeLhMnLNT1uHH+ZlEBasrEAAOQ==", "514-979-7316", true, "07f9190a-d6a3-4fde-bfcc-83275b129876", false, "jordangauthier@noname.com" },
                    { "a935282e-2336-49c3-9811-28742e1242a4", 0, "3a6de4e6-e8b4-4d98-be31-292db445a288", "alexdufour@noname.com", false, "Alex", "Dufour", false, null, "ALEXDUFOUR@NONAME.COM", "ALEXDUFOUR@NONAME.COM", "AQAAAAEAACcQAAAAEJkpl6Zqtod+CrD298Kyfxks25FB6VVhLXpBMi+4eeLhMnLNT1uHH+ZlEBasrEAAOQ==", "514-911-9111", false, "93be084a-cae0-4926-a949-5296f8a3457c", false, "alexdufour@noname.com" },
                    { "ae823a38-13c7-4916-a5b3-a7073cd2ecd1", 0, "a9a894ff-28fd-4059-9559-b5553127c3a1", "alexhamel@noname.com", false, "Alexandre", "Hamel-Boudreault", false, null, "alexhamel@noname.com", "alexhamel@noname.com", "AQAAAAEAACcQAAAAEJkpl6Zqtod+CrD298Kyfxks25FB6VVhLXpBMi+4eeLhMnLNT1uHH+ZlEBasrEAAOQ==", null, false, "51aa32c3-8d7a-43e8-9b56-d456a025d3cb", false, "alexhamel@noname.com" },
                    { "79274c29-3dd8-43c0-b92a-aec049dc087f", 0, "70eba1d5-2ade-4b81-ade4-1ea49e2169f8", "philippesoucy@noname.com", false, "Philippe", "Soucy", false, null, "PHILIPPESOUCY@NONAME.COM", "PHILIPPESOUCY@NONAME.COM", "AQAAAAEAACcQAAAAEJkpl6Zqtod+CrD298Kyfxks25FB6VVhLXpBMi+4eeLhMnLNT1uHH+ZlEBasrEAAOQ==", null, false, "17b984e7-921e-41b3-b3c4-94bc0caccf49", false, "philippesoucy@noname.com" }
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
                    { "14ad00d3-6ab5-49df-b269-44cde5f29e3e", "ee77b2eb-c623-4e2f-a16b-eeebb3744774" },
                    { "a935282e-2336-49c3-9811-28742e1242a4", "ee77b2eb-c623-4e2f-a16b-eeebb3744774" },
                    { "ae823a38-13c7-4916-a5b3-a7073cd2ecd1", "ee77b2eb-c623-4e2f-a16b-eeebb3744774" },
                    { "79274c29-3dd8-43c0-b92a-aec049dc087f", "ee77b2eb-c623-4e2f-a16b-eeebb3744774" }
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
                table: "MessageConversations",
                columns: new[] { "Id", "ReceiverId", "SenderId", "Subject" },
                values: new object[] { 1, "a935282e-2336-49c3-9811-28742e1242a4", "14ad00d3-6ab5-49df-b269-44cde5f29e3e", "tournois de cs pas d'awp" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "BusinessId", "EndDate", "EventTypeId", "PriceToPayToParticipate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 2, 2, "a935282e-2336-49c3-9811-28742e1242a4", 2, new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Souper spaghetti de dufour (Lever de fond)" },
                    { 1, 3, "14ad00d3-6ab5-49df-b269-44cde5f29e3e", 1, new DateTime(2020, 2, 25, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 50.0, new DateTime(2020, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Zumba de dufour" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "MessageConversationId", "UserId" },
                values: new object[,]
                {
                    { 1, "Est-tu pret big ?", 1, "14ad00d3-6ab5-49df-b269-44cde5f29e3e" },
                    { 2, "Je sais pas toi ?", 1, "a935282e-2336-49c3-9811-28742e1242a4" },
                    { 3, "Je sais pas non plus.", 1, "14ad00d3-6ab5-49df-b269-44cde5f29e3e" },
                    { 4, "Mtseee", 1, "a935282e-2336-49c3-9811-28742e1242a4" }
                });

            migrationBuilder.InsertData(
                table: "EventApplicationUsers",
                columns: new[] { "ApplicationUserId", "EventId" },
                values: new object[,]
                {
                    { "14ad00d3-6ab5-49df-b269-44cde5f29e3e", 2 },
                    { "a935282e-2336-49c3-9811-28742e1242a4", 2 },
                    { "79274c29-3dd8-43c0-b92a-aec049dc087f", 2 },
                    { "ae823a38-13c7-4916-a5b3-a7073cd2ecd1", 2 },
                    { "14ad00d3-6ab5-49df-b269-44cde5f29e3e", 1 },
                    { "a935282e-2336-49c3-9811-28742e1242a4", 1 }
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

            migrationBuilder.CreateIndex(
                name: "IX_MessageConversations_ReceiverId",
                table: "MessageConversations",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageConversations_SenderId",
                table: "MessageConversations",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageConversationId",
                table: "Messages",
                column: "MessageConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
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
                name: "Messages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MessageConversations");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
