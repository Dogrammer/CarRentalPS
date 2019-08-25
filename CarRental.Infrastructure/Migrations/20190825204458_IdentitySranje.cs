using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Infrastructure.Migrations
{
    public partial class IdentitySranje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DrivingLicenceNumber = table.Column<string>(maxLength: 8, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Zip = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Brand = table.Column<string>(maxLength: 150, nullable: false),
                    Model = table.Column<string>(maxLength: 100, nullable: false),
                    ProductionYear = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    CarCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarCategories_CarCategoryId",
                        column: x => x.CarCategoryId,
                        principalTable: "CarCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    PickUpLocationId = table.Column<int>(nullable: false),
                    DropOffLocationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Reserved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Locations_DropOffLocationId",
                        column: x => x.DropOffLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DrivingLicenceNumber", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "83dfe8c8-afdc-4a75-a658-fd06fca5127e", 0, "9b9163f7-ce90-4c83-8f9b-0580c3ea4ca1", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "12312312", null, false, "Dorian", false, "Dorianović", false, null, null, null, null, null, false, null, false, null },
                    { "e3971387-4830-42c8-801f-fa4bc3854a89", 0, "b9ebfb1d-8f10-4336-b919-1dfd8ccc38a9", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "99999999", null, false, "Davor", false, "Davorić", false, null, null, null, null, null, false, null, false, null },
                    { "3184cea3-079f-4c7a-95b7-b5125dc84c0e", 0, "c58f376d-643e-4647-88d5-0df91f1e87c4", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "88888888", null, false, "Ivica", false, "Ivić", false, null, null, null, null, null, false, null, false, null },
                    { "87b85a23-8a94-4a62-b868-7b8038a14899", 0, "d1d8a0b7-7495-4c02-94a4-d70772876270", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "55555555", null, false, "Matko", false, "Matković", false, null, null, null, null, null, false, null, false, null },
                    { "7e706949-242b-4011-957f-03c49cd7043e", 0, "f403bc4d-0021-408a-9d85-61b0b76bc59b", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "44444444", null, false, "Pero", false, "Perić", false, null, null, null, null, null, false, null, false, null },
                    { "4f41703b-3e3e-4b5f-b831-e5c590dab7f3", 0, "bf828c55-a359-40d3-9cda-b5fcb6e2e42c", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "33333333", null, false, "Josip", false, "Josipović", false, null, null, null, null, null, false, null, false, null },
                    { "b7886cb7-c3ef-4eda-8a05-afaaf4923f1e", 0, "11cf7363-c522-4602-84b7-5bf14907d26a", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "22222222", null, false, "Marko", false, "Marković", false, null, null, null, null, null, false, null, false, null },
                    { "5740c080-abd1-480b-9c93-e56a4723e47d", 0, "92f10f7c-93d3-42c2-b5bb-034b91ba6d46", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "11111111", null, false, "Ivan", false, "Ivanovic", false, null, null, null, null, null, false, null, false, null },
                    { "b4ae978f-3feb-4dc6-a88b-5f5544aa882e", 0, "2d5abf96-3765-4a5f-8765-66d41f167bff", new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "12121212", null, false, "Dario", false, "Dariović", false, null, null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(2272), false, null, "van" },
                    { 2, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(2602), false, null, "mini-van" },
                    { 3, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(2607), false, null, "limousine" },
                    { 4, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(2607), false, null, "hatchback" },
                    { 5, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(2607), false, null, "coupe" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ModifiedAt", "Name", "Zip" },
                values: new object[,]
                {
                    { 6, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Rijeka", "51000" },
                    { 1, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8353), false, null, "Sisak", "44000" },
                    { 2, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8916), false, null, "Zagreb", "10000" },
                    { 3, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8922), false, null, "Velika Gorica", "10410" },
                    { 14, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8973), false, null, "Vinkovci", "37000" },
                    { 13, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Vukovar", "32000" },
                    { 12, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Šibenik", "22000" },
                    { 11, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Trogir", "21220" },
                    { 10, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Dubrovnik", "20000" },
                    { 4, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8922), false, null, "Osijek", "31000" },
                    { 8, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Krapina", "49000" },
                    { 7, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Varaždin", "42000" },
                    { 5, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8922), false, null, "Slavonski Brod", "35000" },
                    { 9, new DateTime(2019, 8, 25, 20, 44, 57, 936, DateTimeKind.Utc).AddTicks(8928), false, null, "Split", "21000" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CarCategoryId", "Color", "CreatedAt", "IsDeleted", "Mileage", "Model", "ModifiedAt", "ProductionYear" },
                values: new object[,]
                {
                    { 2, "BMW", 3, "Red", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(7458), false, 100500, "320d", null, 2015 },
                    { 3, "Mazda", 3, "Black", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(7481), false, 12500, "3", null, 2014 },
                    { 5, "Mercedes", 3, "Black", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(7481), false, 150000, "c200", null, 2013 },
                    { 7, "Peugeot", 3, "Red", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(7481), false, 100500, "307", null, 2015 },
                    { 1, "Audi", 4, "Black", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(5871), false, 10500, "A4", null, 2018 },
                    { 4, "Audi", 4, "Blue", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(7481), false, 25500, "A7", null, 2018 },
                    { 6, "Citroen", 4, "Yellow", new DateTime(2019, 8, 25, 20, 44, 57, 934, DateTimeKind.Utc).AddTicks(7481), false, 107500, "c3", null, 2010 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CityId", "CreatedAt", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(3867), false, null, "Vukovarska 4c" },
                    { 7, 1, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(4447), false, null, "Vukovarska 15c" },
                    { 2, 2, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(4436), false, null, "Zagrebačka 5" },
                    { 4, 3, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(4441), false, null, "Sisačka 13" },
                    { 3, 4, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(4441), false, null, "Petrova 5" },
                    { 5, 7, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(4441), false, null, "Slavonska 4c" },
                    { 6, 8, new DateTime(2019, 8, 25, 20, 44, 57, 938, DateTimeKind.Utc).AddTicks(4447), false, null, "Petrinjska 4c" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CreatedAt", "CustomerId", "DropOffLocationId", "EndDate", "IsDeleted", "ModifiedAt", "PickUpLocationId", "Remarks", "Reserved", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 4, 2, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(6024), 2, 2, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "blah blah", true, new DateTime(2019, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 6, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(6024), 2, 2, new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "blah blah", true, new DateTime(2019, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 5, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(6064), 2, 2, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "blah blah", true, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 4, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(6070), 2, 2, new DateTime(2019, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "blah blah", true, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 3, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(5996), 5, 4, new DateTime(2016, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "blah blah", true, new DateTime(2016, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, 3, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(3953), 3, 3, new DateTime(2015, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 2, "blah blah", true, new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 1, new DateTime(2019, 8, 25, 20, 44, 57, 939, DateTimeKind.Utc).AddTicks(6024), 6, 3, new DateTime(2018, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "blah blah", true, new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                name: "IX_AspNetUsers_DrivingLicenceNumber",
                table: "AspNetUsers",
                column: "DrivingLicenceNumber",
                unique: true);

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
                name: "IX_CarCategories_Name",
                table: "CarCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarCategoryId",
                table: "Cars",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Zip",
                table: "Cities",
                column: "Zip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_DropOffLocationId",
                table: "Rentals",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PickUpLocationId",
                table: "Rentals",
                column: "PickUpLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
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
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
