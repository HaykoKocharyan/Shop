using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Contact_Person = table.Column<string>(type: "character varying", nullable: true),
                    Email = table.Column<string>(type: "character varying", nullable: true),
                    Phone = table.Column<string>(type: "character varying", nullable: true),
                    Address = table.Column<string>(type: "character varying", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Last_Name = table.Column<string>(type: "character varying", nullable: false),
                    Position = table.Column<string>(type: "character varying", nullable: true),
                    Salary = table.Column<decimal>(type: "numeric", nullable: true),
                    Email = table.Column<string>(type: "character varying", nullable: true),
                    Phone = table.Column<string>(type: "character varying", nullable: true),
                    Adress = table.Column<string>(type: "character varying", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Work_Start_Date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "now()"),
                    Work_End_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Import_Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    Weight_KG = table.Column<double>(type: "double precision", nullable: true),
                    Category = table.Column<string>(type: "character varying", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "now()"),
                    Supplier_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Goods_Id = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    Weight_KG = table.Column<double>(type: "double precision", nullable: true),
                    Total_Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldGoods_Goods_Goods_Id",
                        column: x => x.Goods_Id,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedGoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Reason = table.Column<string>(type: "character varying", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    Weight_Kg = table.Column<double>(type: "double precision", nullable: true),
                    Refund_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Return_Date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "now()"),
                    SoldGood_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnedGoods_SoldGoods_SoldGood_Id",
                        column: x => x.SoldGood_Id,
                        principalTable: "SoldGoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_Supplier_Id",
                table: "Goods",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedGoods_SoldGood_Id",
                table: "ReturnedGoods",
                column: "SoldGood_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoldGoods_Goods_Id",
                table: "SoldGoods",
                column: "Goods_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnedGoods");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "SoldGoods");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
