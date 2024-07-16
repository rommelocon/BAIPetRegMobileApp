using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAIPetRegMobileApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblAccessLevel",
                columns: table => new
                {
                    AccessLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAccessLevel", x => x.AccessLevelID);
                });

            migrationBuilder.CreateTable(
                name: "TblAgencyName",
                columns: table => new
                {
                    AgencyID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAgencyName", x => x.AgencyID);
                });

            migrationBuilder.CreateTable(
                name: "TblMunicipalities",
                columns: table => new
                {
                    MunCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Rcode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    ProvCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MunCity = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    PSGC = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    GeographicLevel = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    OldNames = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    CityClass = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    IncomeClassification = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Pop2020 = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMunicipalities", x => x.MunCode);
                });

            migrationBuilder.CreateTable(
                name: "TblRegistrationOption",
                columns: table => new
                {
                    RegOptID = table.Column<int>(type: "int", nullable: false),
                    RegOptDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRegistrationOption", x => x.RegOptID);
                });

            migrationBuilder.CreateTable(
                name: "TblSexType",
                columns: table => new
                {
                    SexID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSexType", x => x.SexID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "TblBarangay",
                columns: table => new
                {
                    Bcode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Rcode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    ProvCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MunCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    PSGCID = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    BarangayName = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    OldBcode = table.Column<double>(type: "float", nullable: true),
                    OldBryName = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    Pop2020 = table.Column<double>(type: "float", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegOptID = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtensionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SexID = table.Column<int>(type: "int", nullable: true),
                    SexDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CivilStatusCode = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DocumentID = table.Column<int>(type: "int", nullable: true),
                    DocumentDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UploadValidID = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhilSysYN = table.Column<bool>(type: "bit", nullable: true),
                    PhilSysIDNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Signature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AgencyID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AgencyDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccessLevelID = table.Column<int>(type: "int", nullable: true),
                    AccessLevelDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RcodeNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PcodeNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProvinceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    McodeNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MunicipalitiesCities = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bcode = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    BarangayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isEmailSent = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OTPSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OTPSentAttempt = table.Column<int>(type: "int", nullable: true),
                    OTPDateSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblAccessLevel_AccessLevelID",
                        column: x => x.AccessLevelID,
                        principalTable: "TblAccessLevel",
                        principalColumn: "AccessLevelID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblAgencyName_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "TblAgencyName",
                        principalColumn: "AgencyID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblBarangay_Bcode",
                        column: x => x.Bcode,
                        principalTable: "TblBarangay",
                        principalColumn: "Bcode");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblRegistrationOption_RegOptID",
                        column: x => x.RegOptID,
                        principalTable: "TblRegistrationOption",
                        principalColumn: "RegOptID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TblSexType_SexID",
                        column: x => x.SexID,
                        principalTable: "TblSexType",
                        principalColumn: "SexID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_AspNetUsers_AccessLevelID",
                table: "AspNetUsers",
                column: "AccessLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgencyID",
                table: "AspNetUsers",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Bcode",
                table: "AspNetUsers",
                column: "Bcode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegOptID",
                table: "AspNetUsers",
                column: "RegOptID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SexID",
                table: "AspNetUsers",
                column: "SexID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TblBarangay_MunCode",
                table: "TblBarangay",
                column: "MunCode");
        }

        /// <inheritdoc />
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblAccessLevel");

            migrationBuilder.DropTable(
                name: "TblAgencyName");

            migrationBuilder.DropTable(
                name: "TblBarangay");

            migrationBuilder.DropTable(
                name: "TblRegistrationOption");

            migrationBuilder.DropTable(
                name: "TblSexType");

            migrationBuilder.DropTable(
                name: "TblMunicipalities");
        }
    }
}
