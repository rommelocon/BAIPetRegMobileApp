using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAIPetRegMobileApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblAccessLevel_AccessLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblAgencyName_AgencyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblBarangay_Bcode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblRegistrationOption_RegOptID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblSexType_SexID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblBarangay");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Bcode",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSexType",
                table: "TblSexType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblRegistrationOption",
                table: "TblRegistrationOption");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TblAgencyName");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TblAccessLevel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TblSexType");

            migrationBuilder.RenameTable(
                name: "TblSexType",
                newName: "TblSexTypes");

            migrationBuilder.RenameTable(
                name: "TblRegistrationOption",
                newName: "TblRegistrationOptions");

            migrationBuilder.RenameColumn(
                name: "isEmailSent",
                table: "AspNetUsers",
                newName: "IsEmailSent");

            migrationBuilder.AlterColumn<string>(
                name: "Rcode",
                table: "TblMunicipalities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ProvCode",
                table: "TblMunicipalities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<float>(
                name: "Pop2020",
                table: "TblMunicipalities",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PSGC",
                table: "TblMunicipalities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "OldNames",
                table: "TblMunicipalities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "MunCity",
                table: "TblMunicipalities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "IncomeClassification",
                table: "TblMunicipalities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "GeographicLevel",
                table: "TblMunicipalities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "CityClass",
                table: "TblMunicipalities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "MunCode",
                table: "TblMunicipalities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "AgencyID",
                table: "TblAgencyName",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "AgencyDescription",
                table: "TblAgencyName",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessLevelDescription",
                table: "TblAccessLevel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SexDescription",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegOptID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RcodeNum",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhilSysIDNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcodeNum",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MunicipalitiesCities",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "McodeNum",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ExtensionName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentDescription",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bcode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BarangayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgencyID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgencyDescription",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccessLevelDescription",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SexID",
                table: "TblSexTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "SexDescription",
                table: "TblSexTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegOptDescription",
                table: "TblRegistrationOptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSexTypes",
                table: "TblSexTypes",
                column: "SexID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblRegistrationOptions",
                table: "TblRegistrationOptions",
                column: "RegOptID");

            migrationBuilder.CreateTable(
                name: "TblBarangays",
                columns: table => new
                {
                    Bcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MunCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PSGCID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BarangayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OldBcode = table.Column<float>(type: "real", nullable: true),
                    OldBryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pop2020 = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBarangays", x => x.Bcode);
                    table.ForeignKey(
                        name: "FK_TblBarangays_TblMunicipalities_MunCode",
                        column: x => x.MunCode,
                        principalTable: "TblMunicipalities",
                        principalColumn: "MunCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblCivilStatuses",
                columns: table => new
                {
                    CivilCode = table.Column<int>(type: "int", nullable: false),
                    CivilStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCivilStatuses", x => x.CivilCode);
                });

            migrationBuilder.CreateTable(
                name: "TblRegions",
                columns: table => new
                {
                    Rcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PSGC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pop_2020 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TblRegions", x => x.Rcode);
                });

            migrationBuilder.CreateTable(
                name: "TblSpecies",
                columns: table => new
                {
                    SpeciesID = table.Column<int>(type: "int", nullable: false),
                    SpeciesDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSpecies", x => x.SpeciesID);
                });

            migrationBuilder.CreateTable(
                name: "TblProvinces",
                columns: table => new
                {
                    ProvCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PSGC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Old_Names = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pop_2020 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProvinces", x => x.ProvCode);
                    table.ForeignKey(
                        name: "FK_TblProvinces_TblRegions_Rcode",
                        column: x => x.Rcode,
                        principalTable: "TblRegions",
                        principalColumn: "Rcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblMunicipalities_ProvCode",
                table: "TblMunicipalities",
                column: "ProvCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblBarangays_MunCode",
                table: "TblBarangays",
                column: "MunCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblProvinces_Rcode",
                table: "TblProvinces",
                column: "Rcode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblAccessLevel_AccessLevelID",
                table: "AspNetUsers",
                column: "AccessLevelID",
                principalTable: "TblAccessLevel",
                principalColumn: "AccessLevelID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblAgencyName_AgencyID",
                table: "AspNetUsers",
                column: "AgencyID",
                principalTable: "TblAgencyName",
                principalColumn: "AgencyID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblRegistrationOptions_RegOptID",
                table: "AspNetUsers",
                column: "RegOptID",
                principalTable: "TblRegistrationOptions",
                principalColumn: "RegOptID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblSexTypes_SexID",
                table: "AspNetUsers",
                column: "SexID",
                principalTable: "TblSexTypes",
                principalColumn: "SexID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMunicipalities_TblProvinces_ProvCode",
                table: "TblMunicipalities",
                column: "ProvCode",
                principalTable: "TblProvinces",
                principalColumn: "ProvCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblAccessLevel_AccessLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblAgencyName_AgencyID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblRegistrationOptions_RegOptID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblSexTypes_SexID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMunicipalities_TblProvinces_ProvCode",
                table: "TblMunicipalities");

            migrationBuilder.DropTable(
                name: "TblBarangays");

            migrationBuilder.DropTable(
                name: "TblCivilStatuses");

            migrationBuilder.DropTable(
                name: "TblProvinces");

            migrationBuilder.DropTable(
                name: "TblSpecies");

            migrationBuilder.DropTable(
                name: "TblRegions");

            migrationBuilder.DropIndex(
                name: "IX_TblMunicipalities_ProvCode",
                table: "TblMunicipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSexTypes",
                table: "TblSexTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblRegistrationOptions",
                table: "TblRegistrationOptions");

            migrationBuilder.DropColumn(
                name: "AgencyDescription",
                table: "TblAgencyName");

            migrationBuilder.DropColumn(
                name: "AccessLevelDescription",
                table: "TblAccessLevel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SexDescription",
                table: "TblSexTypes");

            migrationBuilder.RenameTable(
                name: "TblSexTypes",
                newName: "TblSexType");

            migrationBuilder.RenameTable(
                name: "TblRegistrationOptions",
                newName: "TblRegistrationOption");

            migrationBuilder.RenameColumn(
                name: "IsEmailSent",
                table: "AspNetUsers",
                newName: "isEmailSent");

            migrationBuilder.AlterColumn<string>(
                name: "Rcode",
                table: "TblMunicipalities",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ProvCode",
                table: "TblMunicipalities",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "Pop2020",
                table: "TblMunicipalities",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PSGC",
                table: "TblMunicipalities",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "OldNames",
                table: "TblMunicipalities",
                type: "NVARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MunCity",
                table: "TblMunicipalities",
                type: "NVARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "IncomeClassification",
                table: "TblMunicipalities",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "GeographicLevel",
                table: "TblMunicipalities",
                type: "NVARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "CityClass",
                table: "TblMunicipalities",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "MunCode",
                table: "TblMunicipalities",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AgencyID",
                table: "TblAgencyName",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TblAgencyName",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TblAccessLevel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SexDescription",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegOptID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RcodeNum",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhilSysIDNumber",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcodeNum",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MunicipalitiesCities",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "McodeNum",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExtensionName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentDescription",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bcode",
                table: "AspNetUsers",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BarangayName",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgencyID",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgencyDescription",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccessLevelDescription",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SexID",
                table: "TblSexType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TblSexType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RegOptDescription",
                table: "TblRegistrationOption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSexType",
                table: "TblSexType",
                column: "SexID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblRegistrationOption",
                table: "TblRegistrationOption",
                column: "RegOptID");

            migrationBuilder.CreateTable(
                name: "TblBarangay",
                columns: table => new
                {
                    Bcode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MunCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    BarangayName = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    OldBcode = table.Column<double>(type: "float", nullable: true),
                    OldBryName = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    PSGCID = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Pop2020 = table.Column<double>(type: "float", nullable: true),
                    ProvCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Rcode = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBarangay", x => x.Bcode);
                    table.ForeignKey(
                        name: "FK_TblBarangay_TblMunicipalities_MunCode",
                        column: x => x.MunCode,
                        principalTable: "TblMunicipalities",
                        principalColumn: "MunCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Bcode",
                table: "AspNetUsers",
                column: "Bcode");

            migrationBuilder.CreateIndex(
                name: "IX_TblBarangay_MunCode",
                table: "TblBarangay",
                column: "MunCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblAccessLevel_AccessLevelID",
                table: "AspNetUsers",
                column: "AccessLevelID",
                principalTable: "TblAccessLevel",
                principalColumn: "AccessLevelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblAgencyName_AgencyID",
                table: "AspNetUsers",
                column: "AgencyID",
                principalTable: "TblAgencyName",
                principalColumn: "AgencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblBarangay_Bcode",
                table: "AspNetUsers",
                column: "Bcode",
                principalTable: "TblBarangay",
                principalColumn: "Bcode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblRegistrationOption_RegOptID",
                table: "AspNetUsers",
                column: "RegOptID",
                principalTable: "TblRegistrationOption",
                principalColumn: "RegOptID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblSexType_SexID",
                table: "AspNetUsers",
                column: "SexID",
                principalTable: "TblSexType",
                principalColumn: "SexID");
        }
    }
}
