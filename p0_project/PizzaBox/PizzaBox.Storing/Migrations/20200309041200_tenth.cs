using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class tenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    CrustId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.CrustId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreAddress = table.Column<string>(nullable: true),
                    StoreCity = table.Column<string>(nullable: true),
                    StoreState = table.Column<string>(nullable: true),
                    StoreZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserPass = table.Column<string>(nullable: true),
                    UserAddress = table.Column<string>(nullable: true),
                    UserCity = table.Column<string>(nullable: true),
                    UserState = table.Column<string>(nullable: true),
                    UserZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false),
                    TimeOfOrder = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    CrustId = table.Column<long>(nullable: false),
                    SizeId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Crust_CrustId",
                        column: x => x.CrustId,
                        principalTable: "Crust",
                        principalColumn: "CrustId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    ToppingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "CrustId", "Name", "Price" },
                values: new object[,]
                {
                    { 637193059197859690L, "Deep Dish", 3.50m },
                    { 637193059197879320L, "New York Style", 2.50m },
                    { 637193059197879364L, "Thin Crust", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "Name", "Price" },
                values: new object[,]
                {
                    { 637193059197887080L, "Large", 12.00m },
                    { 637193059197887366L, "Medium", 10.00m },
                    { 637193059197887384L, "Small", 8.00m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "StoreAddress", "StoreCity", "StoreState", "StoreZip" },
                values: new object[,]
                {
                    { 637193059197888663L, "230 N Center St", "Arlington", "TX", "76011" },
                    { 637193059197889564L, "989 N Walnut Creek Dr", "Mansfield", "TX", "76063" },
                    { 637193059197889610L, "301 W Rendon Crowley Rd", "Burleson", "TX", "76028" }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingId", "Name", "Price" },
                values: new object[,]
                {
                    { 637193059197887918L, "Cheese", 0.25m },
                    { 637193059197888159L, "Pepperoni", 0.50m },
                    { 637193059197888178L, "Tomato Sauce", 0.75m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "LastName", "UserAddress", "UserCity", "UserName", "UserPass", "UserState", "UserZip" },
                values: new object[,]
                {
                    { 637193059197890096L, "A", "B", "2700 E Broad St", "Mansfield", "Person1", "Password12345", "TX", "76063" },
                    { 637193059197891591L, "C", "D", "2602 Mayfield Rd", "Grand Prairie", "Person2", "Password123456", "TX", "75052" },
                    { 637193059197891702L, "A", "G", "1 AT&T Way", "Arlington", "Person3", "Password1234567", "TX", "76011" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizza",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderId",
                table: "Pizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
