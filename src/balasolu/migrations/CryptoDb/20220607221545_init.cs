using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace balasolu.Migrations.CryptoDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trends",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrendType = table.Column<int>(type: "int", nullable: false),
                    BaseAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TradeAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeanPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    HighPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LowPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TrendStart = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    TrendEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trends", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Progressions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgressionType = table.Column<int>(type: "int", nullable: false),
                    BaseAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TradeAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeanPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    HighPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LowPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProgressionStart = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ProgressionEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    TrendId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progressions_Trends_TrendId",
                        column: x => x.TrendId,
                        principalTable: "Trends",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SampleType = table.Column<int>(type: "int", nullable: false),
                    BaseAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TradeAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeanPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    HighPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LowPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SampleStart = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    SampleEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    ProgressionId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samples_Progressions_ProgressionId",
                        column: x => x.ProgressionId,
                        principalTable: "Progressions",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObservationType = table.Column<int>(type: "int", nullable: false),
                    BaseAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TradingAsset = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ObservedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    SampleId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_SampleId",
                table: "Observations",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Progressions_TrendId",
                table: "Progressions",
                column: "TrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_ProgressionId",
                table: "Samples",
                column: "ProgressionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "Progressions");

            migrationBuilder.DropTable(
                name: "Trends");
        }
    }
}
