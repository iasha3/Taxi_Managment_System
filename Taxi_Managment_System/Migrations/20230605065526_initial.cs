using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taxi_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture_year = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrivingLicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Working = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "payment_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shift_cab_CabId",
                        column: x => x.CabId,
                        principalTable: "cab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shift_driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cab_ride",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressStartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDestination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RideEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Canceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cab_ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cab_ride_payment_type_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "payment_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cab_ride_shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cab_ride_status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CabRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cab_ride_status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cab_ride_status_cab_ride_CabRideId",
                        column: x => x.CabRideId,
                        principalTable: "cab_ride",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cab_ride_status_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cab",
                columns: new[] { "Id", "Active", "CarModel", "LicensePlate", "Manufacture_year" },
                values: new object[,]
                {
                    { new Guid("17058a79-c06f-4954-ac65-d817cb5109cc"), false, "Altima", "mrz9fk", 1833086749 },
                    { new Guid("1ff34e0d-4301-4d44-9b9c-8a883c55871a"), false, "Model 3", "w59jw7", 855284559 },
                    { new Guid("20a56bed-f0b6-4000-9bfa-01d2b2db7bc7"), true, "Model 3", "8m3sey", 28987858 },
                    { new Guid("2e6fad70-73c8-4d09-b0ae-6da1b0a73b43"), true, "Taurus", "tek4dg", 1864333650 },
                    { new Guid("2f239779-4aa6-4e8a-a9b2-8d487b0097c9"), true, "Wrangler", "1kqdw4", 1100995239 },
                    { new Guid("334a5e53-989c-4486-9d07-d6ffccb609f8"), false, "Focus", "swnjy8", 1391304054 },
                    { new Guid("3a7420d0-8686-4dc4-b321-d0dc879c452c"), false, "Silverado", "c9d3nk", 400758562 },
                    { new Guid("49fabbc3-d04d-4317-8337-dc48ebe4f82a"), true, "Challenger", "88q0nc", 1245493851 },
                    { new Guid("4e0209c1-f9b5-4612-9acd-d68d16935549"), true, "Malibu", "jlm3x3", 830116241 },
                    { new Guid("5bda64d4-1d57-414f-a61c-69f09cdc2182"), true, "Ranchero", "9ea3zi", 794028919 },
                    { new Guid("839f93a0-7e81-4cf6-9657-3e7a7f61e1bb"), false, "Element", "53yjuf", 1960941622 },
                    { new Guid("a3f32cf7-cde0-40d4-aa40-31798c1b8c5b"), false, "Volt", "j38n52", 691530179 },
                    { new Guid("aa8519ef-a257-4cd2-8fdd-f506ef2da9e3"), true, "Challenger", "dk1f95", 1973978347 },
                    { new Guid("b749b2a6-3fb0-448d-b878-b5da09592d7a"), false, "Mustang", "pckqwt", 314166503 },
                    { new Guid("b99c126b-d873-425a-a056-41ed749a9cc8"), false, "XTS", "onnmfl", 1979092028 },
                    { new Guid("b9be0b98-f0e1-4a6e-930c-c26f8b5c44a0"), true, "Corvette", "7ppp49", 1154209915 },
                    { new Guid("bdceb7ab-4b1b-46e5-8467-80afe6bcb0a2"), true, "Model S", "5yker7", 1559728135 },
                    { new Guid("c5165210-6c72-440a-9f8e-f3e9808cb391"), true, "911", "un6loh", 1732968761 },
                    { new Guid("d88926df-d274-4105-b2e0-8d0f35233ab6"), true, "Golf", "od9fj4", 1889786543 },
                    { new Guid("da917976-0cee-4ea9-b36d-2d4aedc34f37"), true, "El Camino", "yz8jbp", 1099056322 }
                });

            migrationBuilder.InsertData(
                table: "driver",
                columns: new[] { "Id", "BirthDate", "DrivingLicenceNumber", "ExpiryDate", "FirstName", "LastName", "Working" },
                values: new object[,]
                {
                    { new Guid("0ea3fd5e-b301-4786-838d-74eec08f11c2"), new DateTime(2022, 7, 31, 21, 56, 31, 506, DateTimeKind.Local).AddTicks(9919), "ap9rv4yuzj", new DateTime(2023, 5, 10, 4, 14, 44, 410, DateTimeKind.Local).AddTicks(8393), "Marion", "Rogahn", true },
                    { new Guid("34f2f031-8967-459a-9597-754948212054"), new DateTime(2022, 7, 30, 14, 55, 6, 842, DateTimeKind.Local).AddTicks(9355), "jz8xqqd0xf", new DateTime(2022, 12, 12, 12, 40, 4, 257, DateTimeKind.Local).AddTicks(2829), "Ed", "Mayer", false },
                    { new Guid("550fdd9b-e135-4a61-88d7-ce81d27a71d4"), new DateTime(2023, 5, 3, 14, 10, 24, 518, DateTimeKind.Local).AddTicks(9579), "mqp9jkmd7y", new DateTime(2022, 10, 12, 4, 35, 36, 324, DateTimeKind.Local).AddTicks(8562), "Krista", "Howell", false },
                    { new Guid("59dae223-0fa4-4423-bc47-2945202ad8d5"), new DateTime(2022, 8, 25, 1, 57, 5, 439, DateTimeKind.Local).AddTicks(7820), "6aczjev5wo", new DateTime(2022, 12, 20, 22, 55, 58, 709, DateTimeKind.Local).AddTicks(4687), "Jeffery", "Hirthe", false },
                    { new Guid("5eccdfb4-df50-4d1e-89c7-5d498379efe9"), new DateTime(2022, 8, 7, 3, 33, 10, 294, DateTimeKind.Local).AddTicks(89), "az0jmqisw3", new DateTime(2023, 2, 28, 19, 10, 17, 48, DateTimeKind.Local).AddTicks(4802), "Adam", "Brekke", true },
                    { new Guid("660c6427-e57c-40b9-b6e1-c562a8f61171"), new DateTime(2022, 9, 7, 20, 8, 44, 897, DateTimeKind.Local).AddTicks(3584), "lja8v4bu5j", new DateTime(2022, 6, 11, 11, 51, 12, 480, DateTimeKind.Local).AddTicks(3294), "Doreen", "Cronin", true },
                    { new Guid("719056f8-c74b-4eb6-963e-95966666271c"), new DateTime(2022, 12, 16, 22, 32, 8, 323, DateTimeKind.Local).AddTicks(7542), "q9imt49gw3", new DateTime(2023, 4, 27, 13, 56, 53, 434, DateTimeKind.Local).AddTicks(3460), "Sara", "Parker", false },
                    { new Guid("83849adb-75d5-4ad7-a33d-19ebd37c555b"), new DateTime(2022, 9, 11, 16, 20, 6, 942, DateTimeKind.Local).AddTicks(9861), "1v9x7g8clc", new DateTime(2022, 10, 6, 22, 6, 20, 916, DateTimeKind.Local).AddTicks(31), "Amanda", "Murazik", false },
                    { new Guid("84028a3e-ad50-40ef-a693-3355a9ae489b"), new DateTime(2022, 8, 31, 12, 20, 15, 709, DateTimeKind.Local).AddTicks(815), "z9tvcl1ken", new DateTime(2023, 4, 29, 3, 48, 2, 220, DateTimeKind.Local).AddTicks(60), "Homer", "Cassin", false },
                    { new Guid("a5612006-d22a-42b4-aa89-0bc0f558f02d"), new DateTime(2022, 9, 22, 13, 41, 51, 988, DateTimeKind.Local).AddTicks(8534), "xj4uoz8rpg", new DateTime(2022, 7, 6, 23, 50, 2, 883, DateTimeKind.Local).AddTicks(7853), "Allison", "Osinski", true },
                    { new Guid("c493f7a1-2266-4316-be86-886b8c898039"), new DateTime(2023, 4, 23, 11, 52, 56, 653, DateTimeKind.Local).AddTicks(7124), "so8wl9lv9a", new DateTime(2023, 3, 6, 2, 16, 44, 694, DateTimeKind.Local).AddTicks(1097), "Shannon", "Gutmann", true },
                    { new Guid("c561456d-f4e5-447c-b072-c1eb19ed4bbe"), new DateTime(2022, 12, 7, 4, 43, 43, 815, DateTimeKind.Local).AddTicks(6420), "cfizr46qur", new DateTime(2022, 7, 5, 12, 35, 9, 736, DateTimeKind.Local).AddTicks(9674), "Yolanda", "Heidenreich", false },
                    { new Guid("ce2133e9-2a91-4a2f-92c8-20c3cad83c1d"), new DateTime(2023, 2, 18, 8, 5, 10, 402, DateTimeKind.Local).AddTicks(7788), "x8z4m1mph6", new DateTime(2023, 2, 1, 17, 8, 32, 79, DateTimeKind.Local).AddTicks(7036), "James", "Funk", false },
                    { new Guid("d2ad13e5-f56e-4c7a-9744-c7e9d57c7ada"), new DateTime(2023, 4, 13, 10, 47, 1, 913, DateTimeKind.Local).AddTicks(6713), "4o9nm6t1mn", new DateTime(2022, 11, 14, 10, 4, 3, 522, DateTimeKind.Local).AddTicks(8895), "Mathew", "Gleason", false },
                    { new Guid("dd1feacf-b90b-4dfe-a483-98f42a243678"), new DateTime(2022, 8, 5, 22, 40, 19, 544, DateTimeKind.Local).AddTicks(4852), "rv6rkzl43y", new DateTime(2022, 11, 24, 12, 48, 38, 964, DateTimeKind.Local).AddTicks(2240), "Kurt", "Gerlach", true },
                    { new Guid("e9c64a92-4625-496a-b884-375b4b340241"), new DateTime(2022, 10, 12, 11, 43, 1, 710, DateTimeKind.Local).AddTicks(8428), "vi1sgdi9ba", new DateTime(2023, 2, 7, 15, 12, 30, 808, DateTimeKind.Local).AddTicks(4734), "Sean", "Crooks", false },
                    { new Guid("f260175a-eef4-4c2a-ba5f-eecc45d64ead"), new DateTime(2022, 7, 10, 12, 5, 24, 168, DateTimeKind.Local).AddTicks(1111), "n482dx19gv", new DateTime(2022, 7, 8, 20, 35, 52, 352, DateTimeKind.Local).AddTicks(7770), "Carlos", "Rohan", false },
                    { new Guid("fbee05e4-66de-47b3-bf76-1743e840f3e2"), new DateTime(2022, 10, 6, 22, 16, 13, 597, DateTimeKind.Local).AddTicks(7030), "o0yeves5sf", new DateTime(2022, 11, 15, 5, 38, 47, 931, DateTimeKind.Local).AddTicks(5022), "Edna", "Deckow", true },
                    { new Guid("fc322e56-7a6b-4bc6-ae32-342759e78b38"), new DateTime(2023, 4, 15, 17, 9, 38, 328, DateTimeKind.Local).AddTicks(3690), "v9csxei7ho", new DateTime(2023, 5, 26, 23, 54, 1, 357, DateTimeKind.Local).AddTicks(7340), "Mary", "Goldner", false },
                    { new Guid("fe838614-479d-4e6e-bc00-f8588a755e63"), new DateTime(2022, 10, 1, 13, 23, 9, 742, DateTimeKind.Local).AddTicks(7396), "htca3beidd", new DateTime(2022, 10, 18, 13, 21, 55, 687, DateTimeKind.Local).AddTicks(6052), "Andrew", "Douglas", true }
                });

            migrationBuilder.InsertData(
                table: "payment_type",
                columns: new[] { "Id", "NameType" },
                values: new object[,]
                {
                    { new Guid("0eff2385-86f2-4113-bb02-3b9d382083db"), "карта" },
                    { new Guid("985e82da-34d5-4312-b988-f61109671c7c"), "готівка" },
                    { new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), "карта" },
                    { new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), "карта" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { new Guid("1322b7a1-90bd-475f-bdc7-30a308b4bb61"), "В дорозі" },
                    { new Guid("154ea15b-a524-40a6-89ff-2cd5efb69aed"), "В дорозі" },
                    { new Guid("1767f2fd-a497-4162-a34e-23ecbeb7b74d"), "Очікує" },
                    { new Guid("41f91944-6ad8-493f-bcc5-5f7b4dc342f2"), "Подорож закінчена" },
                    { new Guid("51b4484f-6d43-4dfd-bf70-6febcdbb2522"), "Подорож закінчена" },
                    { new Guid("b370867a-2261-42eb-9b7b-2fd6bd26a224"), "Очікує" }
                });

            migrationBuilder.InsertData(
                table: "shift",
                columns: new[] { "Id", "CabId", "DriverId", "ShiftEndTime", "ShiftStartTime" },
                values: new object[,]
                {
                    { new Guid("1699f09b-0518-449c-a5d3-ccd2c9460d64"), new Guid("5bda64d4-1d57-414f-a61c-69f09cdc2182"), new Guid("dd1feacf-b90b-4dfe-a483-98f42a243678"), new DateTime(2022, 9, 22, 11, 54, 30, 802, DateTimeKind.Local).AddTicks(5453), new DateTime(2022, 9, 22, 20, 32, 17, 938, DateTimeKind.Local).AddTicks(5045) },
                    { new Guid("1a59f6e7-ba15-4f60-9ba1-210a1641bc99"), new Guid("4e0209c1-f9b5-4612-9acd-d68d16935549"), new Guid("5eccdfb4-df50-4d1e-89c7-5d498379efe9"), new DateTime(2023, 3, 21, 6, 23, 27, 712, DateTimeKind.Local).AddTicks(3651), new DateTime(2023, 3, 21, 13, 5, 16, 109, DateTimeKind.Local).AddTicks(3886) },
                    { new Guid("1c5dfd11-6e2c-47a3-bee0-81640bc27c27"), new Guid("17058a79-c06f-4954-ac65-d817cb5109cc"), new Guid("f260175a-eef4-4c2a-ba5f-eecc45d64ead"), new DateTime(2022, 10, 22, 9, 44, 54, 842, DateTimeKind.Local).AddTicks(3127), new DateTime(2022, 10, 22, 21, 23, 37, 489, DateTimeKind.Local).AddTicks(7703) },
                    { new Guid("3453203c-ed99-4fb1-9f36-62a4b0f788cf"), new Guid("3a7420d0-8686-4dc4-b321-d0dc879c452c"), new Guid("59dae223-0fa4-4423-bc47-2945202ad8d5"), new DateTime(2022, 7, 12, 15, 19, 27, 139, DateTimeKind.Local).AddTicks(5948), new DateTime(2022, 7, 12, 17, 52, 49, 83, DateTimeKind.Local).AddTicks(5076) },
                    { new Guid("3e900077-4087-4b66-8578-9dd2b562fb51"), new Guid("49fabbc3-d04d-4317-8337-dc48ebe4f82a"), new Guid("c493f7a1-2266-4316-be86-886b8c898039"), new DateTime(2023, 3, 11, 2, 40, 15, 535, DateTimeKind.Local).AddTicks(5896), new DateTime(2023, 3, 11, 3, 16, 43, 183, DateTimeKind.Local).AddTicks(2611) },
                    { new Guid("416d4501-2004-4d48-ac1a-c83422a31563"), new Guid("334a5e53-989c-4486-9d07-d6ffccb609f8"), new Guid("c561456d-f4e5-447c-b072-c1eb19ed4bbe"), new DateTime(2022, 8, 14, 4, 13, 26, 856, DateTimeKind.Local).AddTicks(8578), new DateTime(2022, 8, 14, 8, 50, 47, 725, DateTimeKind.Local).AddTicks(2643) },
                    { new Guid("453baad2-d6b8-449c-87ad-1e30755ce5f0"), new Guid("da917976-0cee-4ea9-b36d-2d4aedc34f37"), new Guid("59dae223-0fa4-4423-bc47-2945202ad8d5"), new DateTime(2022, 10, 31, 12, 23, 35, 790, DateTimeKind.Local).AddTicks(439), new DateTime(2022, 10, 31, 18, 36, 13, 469, DateTimeKind.Local).AddTicks(5715) },
                    { new Guid("5d31f987-4754-4a41-851c-bc2c56e7b812"), new Guid("d88926df-d274-4105-b2e0-8d0f35233ab6"), new Guid("a5612006-d22a-42b4-aa89-0bc0f558f02d"), new DateTime(2022, 7, 25, 15, 6, 3, 445, DateTimeKind.Local).AddTicks(9941), new DateTime(2022, 7, 25, 19, 43, 59, 623, DateTimeKind.Local).AddTicks(6633) },
                    { new Guid("6405f468-ab27-4777-b47f-6f4279823e87"), new Guid("bdceb7ab-4b1b-46e5-8467-80afe6bcb0a2"), new Guid("83849adb-75d5-4ad7-a33d-19ebd37c555b"), new DateTime(2023, 3, 21, 2, 28, 23, 106, DateTimeKind.Local).AddTicks(6305), new DateTime(2023, 3, 21, 10, 34, 27, 472, DateTimeKind.Local).AddTicks(6232) },
                    { new Guid("6601fc2b-30e8-4aa9-b84d-655484c7d375"), new Guid("aa8519ef-a257-4cd2-8fdd-f506ef2da9e3"), new Guid("719056f8-c74b-4eb6-963e-95966666271c"), new DateTime(2022, 6, 13, 21, 8, 56, 212, DateTimeKind.Local).AddTicks(3965), new DateTime(2022, 6, 14, 2, 39, 57, 78, DateTimeKind.Local).AddTicks(9219) },
                    { new Guid("6870ac8f-13a1-424f-bbda-ae8533e892e2"), new Guid("b99c126b-d873-425a-a056-41ed749a9cc8"), new Guid("719056f8-c74b-4eb6-963e-95966666271c"), new DateTime(2023, 2, 2, 4, 53, 29, 943, DateTimeKind.Local).AddTicks(5139), new DateTime(2023, 2, 2, 5, 38, 8, 980, DateTimeKind.Local).AddTicks(2621) },
                    { new Guid("7494d324-b215-48e4-828b-c0216d232b6d"), new Guid("334a5e53-989c-4486-9d07-d6ffccb609f8"), new Guid("83849adb-75d5-4ad7-a33d-19ebd37c555b"), new DateTime(2023, 2, 27, 22, 46, 18, 782, DateTimeKind.Local).AddTicks(1908), new DateTime(2023, 2, 28, 8, 35, 20, 365, DateTimeKind.Local).AddTicks(5318) },
                    { new Guid("8633f0ad-bb06-4172-b77e-5a5f4ff5c6f0"), new Guid("49fabbc3-d04d-4317-8337-dc48ebe4f82a"), new Guid("34f2f031-8967-459a-9597-754948212054"), new DateTime(2023, 2, 25, 6, 51, 35, 2, DateTimeKind.Local).AddTicks(3095), new DateTime(2023, 2, 25, 8, 3, 5, 593, DateTimeKind.Local).AddTicks(9299) },
                    { new Guid("992c970b-879a-4104-8659-da1ff5a97ee8"), new Guid("3a7420d0-8686-4dc4-b321-d0dc879c452c"), new Guid("d2ad13e5-f56e-4c7a-9744-c7e9d57c7ada"), new DateTime(2022, 7, 22, 10, 21, 12, 383, DateTimeKind.Local).AddTicks(8516), new DateTime(2022, 7, 22, 20, 45, 31, 763, DateTimeKind.Local).AddTicks(8586) },
                    { new Guid("9b94d825-fd94-43e3-997d-cde536917e52"), new Guid("aa8519ef-a257-4cd2-8fdd-f506ef2da9e3"), new Guid("84028a3e-ad50-40ef-a693-3355a9ae489b"), new DateTime(2022, 6, 20, 22, 53, 19, 128, DateTimeKind.Local).AddTicks(321), new DateTime(2022, 6, 21, 1, 57, 5, 138, DateTimeKind.Local).AddTicks(5270) },
                    { new Guid("be5527a5-b550-4682-8f1b-5abbe1e62dc9"), new Guid("17058a79-c06f-4954-ac65-d817cb5109cc"), new Guid("34f2f031-8967-459a-9597-754948212054"), new DateTime(2023, 4, 23, 17, 1, 30, 289, DateTimeKind.Local).AddTicks(9670), new DateTime(2023, 4, 24, 1, 37, 43, 842, DateTimeKind.Local).AddTicks(8288) },
                    { new Guid("cc76a5f4-115f-471e-a6b6-077916b316c5"), new Guid("3a7420d0-8686-4dc4-b321-d0dc879c452c"), new Guid("d2ad13e5-f56e-4c7a-9744-c7e9d57c7ada"), new DateTime(2022, 11, 30, 7, 59, 1, 299, DateTimeKind.Local).AddTicks(8015), new DateTime(2022, 11, 30, 19, 43, 16, 643, DateTimeKind.Local).AddTicks(6967) },
                    { new Guid("d76dd061-1f7a-4ba8-be7f-6262e75ae6dc"), new Guid("c5165210-6c72-440a-9f8e-f3e9808cb391"), new Guid("34f2f031-8967-459a-9597-754948212054"), new DateTime(2022, 10, 23, 18, 13, 2, 667, DateTimeKind.Local).AddTicks(9342), new DateTime(2022, 10, 23, 18, 56, 25, 410, DateTimeKind.Local).AddTicks(2771) },
                    { new Guid("d827f272-77b3-4fdf-9011-d6754478e708"), new Guid("17058a79-c06f-4954-ac65-d817cb5109cc"), new Guid("fc322e56-7a6b-4bc6-ae32-342759e78b38"), new DateTime(2023, 6, 5, 3, 6, 11, 125, DateTimeKind.Local).AddTicks(4615), new DateTime(2023, 6, 5, 12, 43, 59, 994, DateTimeKind.Local).AddTicks(6764) },
                    { new Guid("e68a650b-26e9-4e44-be09-1d50833329d0"), new Guid("d88926df-d274-4105-b2e0-8d0f35233ab6"), new Guid("fbee05e4-66de-47b3-bf76-1743e840f3e2"), new DateTime(2023, 2, 27, 11, 22, 4, 201, DateTimeKind.Local).AddTicks(2348), new DateTime(2023, 2, 27, 17, 59, 22, 180, DateTimeKind.Local).AddTicks(9535) }
                });

            migrationBuilder.InsertData(
                table: "cab_ride",
                columns: new[] { "Id", "AddressDestination", "AddressStartingPoint", "Canceled", "PaymentTypeId", "Price", "RideEndTime", "RideStartTime", "ShiftId" },
                values: new object[,]
                {
                    { new Guid("10adaefe-e65a-4149-8c21-96dd7a9a1078"), "523 Gusikowski Way", "8399 Cormier Row", true, new Guid("985e82da-34d5-4312-b988-f61109671c7c"), 578.61m, new DateTime(2022, 11, 22, 12, 32, 13, 784, DateTimeKind.Local).AddTicks(8656), new DateTime(2022, 11, 22, 12, 10, 50, 854, DateTimeKind.Local).AddTicks(6304), new Guid("e68a650b-26e9-4e44-be09-1d50833329d0") },
                    { new Guid("1b1c8b84-4042-4b0e-a5bf-3d54bd7d06b5"), "9959 Borer Rapids", "48701 Hallie Park", true, new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), 312.17m, new DateTime(2023, 4, 15, 18, 1, 36, 451, DateTimeKind.Local).AddTicks(6821), new DateTime(2023, 4, 15, 17, 40, 0, 132, DateTimeKind.Local).AddTicks(9910), new Guid("8633f0ad-bb06-4172-b77e-5a5f4ff5c6f0") },
                    { new Guid("1e1c7fb6-7997-4297-b829-ee818635329a"), "98916 Gutmann Ports", "8273 Collins Fort", false, new Guid("0eff2385-86f2-4113-bb02-3b9d382083db"), 64.85m, new DateTime(2023, 5, 20, 2, 3, 46, 333, DateTimeKind.Local).AddTicks(5745), new DateTime(2023, 5, 20, 1, 35, 48, 116, DateTimeKind.Local).AddTicks(7486), new Guid("3453203c-ed99-4fb1-9f36-62a4b0f788cf") },
                    { new Guid("2b71ef8e-dc62-4090-b859-1d64b12eeef8"), "7838 Dario Views", "06346 Doyle Extensions", false, new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), 676.29m, new DateTime(2023, 6, 2, 2, 3, 21, 228, DateTimeKind.Local).AddTicks(7115), new DateTime(2023, 6, 2, 1, 40, 25, 544, DateTimeKind.Local).AddTicks(4780), new Guid("6405f468-ab27-4777-b47f-6f4279823e87") },
                    { new Guid("2dc3dc15-be66-4fdb-9897-573849ceae43"), "115 Alia Centers", "469 Kristin Turnpike", false, new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), 907.04m, new DateTime(2022, 10, 17, 16, 15, 6, 524, DateTimeKind.Local).AddTicks(617), new DateTime(2022, 10, 17, 16, 11, 15, 244, DateTimeKind.Local).AddTicks(8077), new Guid("3e900077-4087-4b66-8578-9dd2b562fb51") },
                    { new Guid("369373ed-c6ff-4284-8048-d4c145f1e9b4"), "62940 Lynch Union", "6560 Fatima Islands", false, new Guid("985e82da-34d5-4312-b988-f61109671c7c"), 66.92m, new DateTime(2022, 11, 13, 12, 25, 13, 179, DateTimeKind.Local).AddTicks(4317), new DateTime(2022, 11, 13, 12, 14, 32, 151, DateTimeKind.Local).AddTicks(3413), new Guid("3e900077-4087-4b66-8578-9dd2b562fb51") },
                    { new Guid("3b3598ce-de43-4bba-8b09-3605f202ed8a"), "85489 Adolph Station", "624 Auer Station", false, new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), 609.83m, new DateTime(2022, 8, 8, 1, 39, 31, 715, DateTimeKind.Local).AddTicks(970), new DateTime(2022, 8, 8, 1, 38, 21, 82, DateTimeKind.Local).AddTicks(6345), new Guid("453baad2-d6b8-449c-87ad-1e30755ce5f0") },
                    { new Guid("73f727ed-72f9-476b-a69e-526b0792c433"), "25099 Theodore Coves", "16744 White Isle", true, new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), 646.43m, new DateTime(2022, 7, 13, 13, 39, 40, 891, DateTimeKind.Local).AddTicks(4403), new DateTime(2022, 7, 13, 13, 25, 15, 343, DateTimeKind.Local).AddTicks(7446), new Guid("8633f0ad-bb06-4172-b77e-5a5f4ff5c6f0") },
                    { new Guid("75855a1c-a2a7-4148-abfe-4dd74258f42d"), "5495 Bradtke Port", "51399 Lesly Roads", false, new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), 229.82m, new DateTime(2023, 1, 14, 1, 0, 23, 987, DateTimeKind.Local).AddTicks(5348), new DateTime(2023, 1, 14, 0, 39, 29, 174, DateTimeKind.Local).AddTicks(1335), new Guid("7494d324-b215-48e4-828b-c0216d232b6d") },
                    { new Guid("7a2cb453-04e3-47ab-816f-ee492ed8aed8"), "0682 Johnston Lodge", "132 Earline Unions", true, new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), 949.18m, new DateTime(2022, 7, 3, 5, 20, 52, 643, DateTimeKind.Local).AddTicks(7957), new DateTime(2022, 7, 3, 5, 16, 23, 668, DateTimeKind.Local).AddTicks(5027), new Guid("9b94d825-fd94-43e3-997d-cde536917e52") },
                    { new Guid("8a1e2689-36f2-4dd1-886b-4f192f6db7f3"), "5483 Dagmar Circle", "89871 Boehm Glen", true, new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), 730.08m, new DateTime(2023, 1, 22, 13, 17, 50, 131, DateTimeKind.Local).AddTicks(9394), new DateTime(2023, 1, 22, 12, 49, 14, 536, DateTimeKind.Local).AddTicks(8702), new Guid("6601fc2b-30e8-4aa9-b84d-655484c7d375") },
                    { new Guid("9070c2d9-d6e9-4895-bd6a-5eeea2f3b074"), "1011 Armando Mills", "919 Bernita Curve", false, new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), 327.37m, new DateTime(2023, 4, 9, 21, 51, 40, 601, DateTimeKind.Local).AddTicks(5380), new DateTime(2023, 4, 9, 21, 40, 33, 576, DateTimeKind.Local).AddTicks(9592), new Guid("be5527a5-b550-4682-8f1b-5abbe1e62dc9") },
                    { new Guid("acf64304-6347-464e-a1bc-b71168c5dcf1"), "1773 Hoppe Mews", "977 Herzog Inlet", true, new Guid("0eff2385-86f2-4113-bb02-3b9d382083db"), 619.04m, new DateTime(2023, 1, 2, 2, 7, 24, 516, DateTimeKind.Local).AddTicks(5241), new DateTime(2023, 1, 2, 1, 43, 5, 353, DateTimeKind.Local).AddTicks(7293), new Guid("6601fc2b-30e8-4aa9-b84d-655484c7d375") },
                    { new Guid("b3118988-0bc1-42a6-bd2b-c1fb968a7743"), "08638 Renner Ridge", "2633 Jessie Fords", false, new Guid("0eff2385-86f2-4113-bb02-3b9d382083db"), 85.82m, new DateTime(2022, 6, 11, 17, 38, 9, 88, DateTimeKind.Local).AddTicks(5089), new DateTime(2022, 6, 11, 17, 26, 44, 611, DateTimeKind.Local).AddTicks(6267), new Guid("6405f468-ab27-4777-b47f-6f4279823e87") },
                    { new Guid("c0bb6831-a382-4ba3-9642-8f3974b08af8"), "06327 Joseph Ville", "5734 Larissa Course", false, new Guid("985e82da-34d5-4312-b988-f61109671c7c"), 937.56m, new DateTime(2022, 8, 12, 8, 42, 59, 383, DateTimeKind.Local).AddTicks(1249), new DateTime(2022, 8, 12, 8, 40, 48, 406, DateTimeKind.Local).AddTicks(9651), new Guid("8633f0ad-bb06-4172-b77e-5a5f4ff5c6f0") },
                    { new Guid("d3db81d3-4e36-45ca-b8ea-51495ecb91dd"), "9725 Ledner Crest", "77016 Douglas Fort", true, new Guid("ecdec2c7-1c74-4d17-86b0-f2df3252774b"), 97.34m, new DateTime(2022, 12, 13, 20, 50, 25, 196, DateTimeKind.Local).AddTicks(2183), new DateTime(2022, 12, 13, 20, 28, 5, 530, DateTimeKind.Local).AddTicks(4260), new Guid("416d4501-2004-4d48-ac1a-c83422a31563") },
                    { new Guid("e5a32545-6ae7-4957-a4e4-8e7ef3655c89"), "6442 Anna Rapids", "13968 Lockman Point", false, new Guid("0eff2385-86f2-4113-bb02-3b9d382083db"), 459.49m, new DateTime(2022, 6, 16, 20, 20, 30, 556, DateTimeKind.Local).AddTicks(8287), new DateTime(2022, 6, 16, 19, 57, 8, 721, DateTimeKind.Local).AddTicks(97), new Guid("3453203c-ed99-4fb1-9f36-62a4b0f788cf") },
                    { new Guid("ef663dd2-e114-4a47-b67e-80281d54f138"), "74765 Luettgen Extensions", "6368 Zachery Motorway", true, new Guid("985e82da-34d5-4312-b988-f61109671c7c"), 444.34m, new DateTime(2022, 6, 18, 20, 47, 38, 345, DateTimeKind.Local).AddTicks(2966), new DateTime(2022, 6, 18, 20, 43, 3, 493, DateTimeKind.Local).AddTicks(7177), new Guid("1a59f6e7-ba15-4f60-9ba1-210a1641bc99") },
                    { new Guid("f45fcc9a-3d21-4614-8255-85de9b7d1e59"), "2629 Herzog Club", "418 Rosenbaum Drive", true, new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), 62.23m, new DateTime(2022, 8, 11, 19, 2, 37, 140, DateTimeKind.Local).AddTicks(4189), new DateTime(2022, 8, 11, 18, 57, 59, 581, DateTimeKind.Local).AddTicks(4202), new Guid("8633f0ad-bb06-4172-b77e-5a5f4ff5c6f0") },
                    { new Guid("f9d3665f-2743-49d9-b7e1-de9551c9ba0e"), "83949 Bins Walks", "43799 Lambert Court", false, new Guid("b5d27d34-a8db-42e7-ab90-dd186288dd4e"), 785.22m, new DateTime(2022, 11, 10, 10, 8, 29, 900, DateTimeKind.Local).AddTicks(7954), new DateTime(2022, 11, 10, 9, 40, 41, 646, DateTimeKind.Local).AddTicks(8934), new Guid("be5527a5-b550-4682-8f1b-5abbe1e62dc9") }
                });

            migrationBuilder.InsertData(
                table: "cab_ride_status",
                columns: new[] { "Id", "CabRideId", "StatusId", "StatusTime" },
                values: new object[,]
                {
                    { new Guid("04312449-7acc-489f-8fc4-589449b47ab0"), new Guid("e5a32545-6ae7-4957-a4e4-8e7ef3655c89"), new Guid("1767f2fd-a497-4162-a34e-23ecbeb7b74d"), new DateTime(2022, 10, 4, 14, 58, 34, 140, DateTimeKind.Local).AddTicks(7374) },
                    { new Guid("1c5d9197-50fa-4ebb-9ad6-0244c3bdf547"), new Guid("c0bb6831-a382-4ba3-9642-8f3974b08af8"), new Guid("51b4484f-6d43-4dfd-bf70-6febcdbb2522"), new DateTime(2023, 3, 2, 21, 11, 44, 784, DateTimeKind.Local).AddTicks(5387) },
                    { new Guid("257d63e5-7c28-4e18-80a8-cc086c2dc22a"), new Guid("e5a32545-6ae7-4957-a4e4-8e7ef3655c89"), new Guid("41f91944-6ad8-493f-bcc5-5f7b4dc342f2"), new DateTime(2022, 9, 6, 6, 30, 15, 439, DateTimeKind.Local).AddTicks(2653) },
                    { new Guid("2684d3ee-3df4-4709-b786-69852fa58941"), new Guid("e5a32545-6ae7-4957-a4e4-8e7ef3655c89"), new Guid("1767f2fd-a497-4162-a34e-23ecbeb7b74d"), new DateTime(2023, 1, 6, 18, 50, 28, 362, DateTimeKind.Local).AddTicks(5665) },
                    { new Guid("2892eda1-87aa-4938-b979-4848a8710686"), new Guid("1e1c7fb6-7997-4297-b829-ee818635329a"), new Guid("b370867a-2261-42eb-9b7b-2fd6bd26a224"), new DateTime(2022, 7, 18, 12, 19, 14, 623, DateTimeKind.Local).AddTicks(6251) },
                    { new Guid("37fbef7f-2587-4391-9752-b2169e624aba"), new Guid("1b1c8b84-4042-4b0e-a5bf-3d54bd7d06b5"), new Guid("154ea15b-a524-40a6-89ff-2cd5efb69aed"), new DateTime(2022, 12, 13, 20, 4, 35, 166, DateTimeKind.Local).AddTicks(9902) },
                    { new Guid("3b6944f8-a888-4850-b6b0-bd16e325974a"), new Guid("9070c2d9-d6e9-4895-bd6a-5eeea2f3b074"), new Guid("51b4484f-6d43-4dfd-bf70-6febcdbb2522"), new DateTime(2022, 12, 25, 12, 17, 11, 599, DateTimeKind.Local).AddTicks(7400) },
                    { new Guid("3e2ffe92-880b-4dfa-b50a-c1857a9afca2"), new Guid("7a2cb453-04e3-47ab-816f-ee492ed8aed8"), new Guid("41f91944-6ad8-493f-bcc5-5f7b4dc342f2"), new DateTime(2022, 9, 20, 22, 3, 20, 677, DateTimeKind.Local).AddTicks(6714) },
                    { new Guid("489e0666-a14d-4515-b70f-dafa527b1645"), new Guid("9070c2d9-d6e9-4895-bd6a-5eeea2f3b074"), new Guid("154ea15b-a524-40a6-89ff-2cd5efb69aed"), new DateTime(2022, 6, 10, 1, 1, 23, 150, DateTimeKind.Local).AddTicks(4898) },
                    { new Guid("695f7b5f-e653-4222-b28b-dce5928c6958"), new Guid("9070c2d9-d6e9-4895-bd6a-5eeea2f3b074"), new Guid("1322b7a1-90bd-475f-bdc7-30a308b4bb61"), new DateTime(2022, 10, 20, 6, 14, 5, 797, DateTimeKind.Local).AddTicks(3628) },
                    { new Guid("76407e05-9a1b-47d3-b9ce-d7900510160c"), new Guid("7a2cb453-04e3-47ab-816f-ee492ed8aed8"), new Guid("41f91944-6ad8-493f-bcc5-5f7b4dc342f2"), new DateTime(2023, 3, 20, 7, 10, 46, 746, DateTimeKind.Local).AddTicks(8334) },
                    { new Guid("8756319a-382c-4ff1-ae46-9ed9917bd243"), new Guid("e5a32545-6ae7-4957-a4e4-8e7ef3655c89"), new Guid("1767f2fd-a497-4162-a34e-23ecbeb7b74d"), new DateTime(2022, 9, 17, 16, 23, 9, 282, DateTimeKind.Local).AddTicks(3496) },
                    { new Guid("97cfa1c2-10f1-4499-bf5b-a1aee662f80e"), new Guid("2dc3dc15-be66-4fdb-9897-573849ceae43"), new Guid("1322b7a1-90bd-475f-bdc7-30a308b4bb61"), new DateTime(2022, 11, 2, 16, 41, 23, 416, DateTimeKind.Local).AddTicks(3955) },
                    { new Guid("998fe270-e059-4064-a635-3a4bec456e29"), new Guid("f9d3665f-2743-49d9-b7e1-de9551c9ba0e"), new Guid("51b4484f-6d43-4dfd-bf70-6febcdbb2522"), new DateTime(2023, 3, 25, 11, 30, 52, 187, DateTimeKind.Local).AddTicks(909) },
                    { new Guid("bf7c25c7-1aba-4b54-8ad9-4aa7f1916f3b"), new Guid("1e1c7fb6-7997-4297-b829-ee818635329a"), new Guid("b370867a-2261-42eb-9b7b-2fd6bd26a224"), new DateTime(2023, 4, 13, 8, 2, 24, 959, DateTimeKind.Local).AddTicks(1731) },
                    { new Guid("bfff398a-9e80-475d-9095-4461d0d496af"), new Guid("73f727ed-72f9-476b-a69e-526b0792c433"), new Guid("51b4484f-6d43-4dfd-bf70-6febcdbb2522"), new DateTime(2023, 3, 9, 19, 32, 53, 54, DateTimeKind.Local).AddTicks(6298) },
                    { new Guid("c660923d-33d8-4127-a79f-c46fb3573923"), new Guid("1e1c7fb6-7997-4297-b829-ee818635329a"), new Guid("b370867a-2261-42eb-9b7b-2fd6bd26a224"), new DateTime(2022, 9, 2, 6, 59, 22, 563, DateTimeKind.Local).AddTicks(4139) },
                    { new Guid("c8e8b7e3-139f-4313-a7a1-1599d115ed5c"), new Guid("d3db81d3-4e36-45ca-b8ea-51495ecb91dd"), new Guid("1767f2fd-a497-4162-a34e-23ecbeb7b74d"), new DateTime(2023, 2, 13, 4, 5, 53, 249, DateTimeKind.Local).AddTicks(2758) },
                    { new Guid("d1479dbd-aaca-4c0e-87ab-5ac281be4008"), new Guid("c0bb6831-a382-4ba3-9642-8f3974b08af8"), new Guid("154ea15b-a524-40a6-89ff-2cd5efb69aed"), new DateTime(2022, 7, 15, 10, 20, 34, 119, DateTimeKind.Local).AddTicks(5422) },
                    { new Guid("eb9ecd3b-b801-403f-bcca-c123ba491b0d"), new Guid("2dc3dc15-be66-4fdb-9897-573849ceae43"), new Guid("51b4484f-6d43-4dfd-bf70-6febcdbb2522"), new DateTime(2022, 8, 12, 13, 7, 5, 162, DateTimeKind.Local).AddTicks(2403) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cab_ride_PaymentTypeId",
                table: "cab_ride",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cab_ride_ShiftId",
                table: "cab_ride",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_cab_ride_status_CabRideId",
                table: "cab_ride_status",
                column: "CabRideId");

            migrationBuilder.CreateIndex(
                name: "IX_cab_ride_status_StatusId",
                table: "cab_ride_status",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_shift_CabId",
                table: "shift",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_shift_DriverId",
                table: "shift",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cab_ride_status");

            migrationBuilder.DropTable(
                name: "cab_ride");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "payment_type");

            migrationBuilder.DropTable(
                name: "shift");

            migrationBuilder.DropTable(
                name: "cab");

            migrationBuilder.DropTable(
                name: "driver");
        }
    }
}
