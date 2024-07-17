﻿// <auto-generated />
using System;
using BAIPetRegMobileApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BAIPetRegMobileApp.Api.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblAccessLevel", b =>
                {
                    b.Property<int>("AccessLevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessLevelID"));

                    b.Property<string>("AccessLevelDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccessLevelID");

                    b.ToTable("TblAccessLevel");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblAgencyName", b =>
                {
                    b.Property<string>("AgencyID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgencyDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AgencyID");

                    b.ToTable("TblAgencyName");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblBarangays", b =>
                {
                    b.Property<string>("Bcode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Bcode");

                    b.Property<string>("BarangayName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("BarangayName");

                    b.Property<string>("MunCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MunCode");

                    b.Property<float?>("OldBcode")
                        .HasColumnType("real")
                        .HasColumnName("OldBcode");

                    b.Property<string>("OldBryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("OldBryName");

                    b.Property<string>("PSGCID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PSGCID");

                    b.Property<float?>("Population2020")
                        .HasColumnType("real")
                        .HasColumnName("Pop2020");

                    b.Property<string>("ProvCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProvCode");

                    b.Property<string>("Rcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Rcode");

                    b.HasKey("Bcode");

                    b.HasIndex("MunCode");

                    b.ToTable("TblBarangays");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblCivilStatus", b =>
                {
                    b.Property<int>("CivilCode")
                        .HasColumnType("int");

                    b.Property<string>("CivilStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CivilCode");

                    b.ToTable("TblCivilStatuses");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblMunicipalities", b =>
                {
                    b.Property<string>("MunCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MunCode");

                    b.Property<string>("CityClass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CityClass");

                    b.Property<string>("GeographicLevel")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("GeographicLevel");

                    b.Property<string>("IncomeClassification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("IncomeClassification");

                    b.Property<string>("MunCity")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("MunCity");

                    b.Property<string>("OldNames")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("OldNames");

                    b.Property<string>("PSGC")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PSGC");

                    b.Property<float?>("Population2020")
                        .HasColumnType("real")
                        .HasColumnName("Pop2020");

                    b.Property<string>("ProvCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProvCode");

                    b.Property<string>("Rcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Rcode");

                    b.HasKey("MunCode");

                    b.HasIndex("ProvCode");

                    b.ToTable("TblMunicipalities");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblProvinces", b =>
                {
                    b.Property<string>("ProvCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ProvCode");

                    b.Property<string>("OldNames")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Old_Names");

                    b.Property<string>("PSGC")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PSGC");

                    b.Property<int?>("Population2020")
                        .HasColumnType("int")
                        .HasColumnName("Pop_2020");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ProvinceName");

                    b.Property<string>("Rcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Rcode");

                    b.HasKey("ProvCode");

                    b.HasIndex("Rcode");

                    b.ToTable("TblProvinces");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblRegions", b =>
                {
                    b.Property<string>("Rcode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Rcode");

                    b.Property<string>("PSGC")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PSGC");

                    b.Property<int?>("Population2020")
                        .HasColumnType("int")
                        .HasColumnName("Pop_2020");

                    b.Property<string>("RegionName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Region");

                    b.HasKey("Rcode")
                        .HasName("TblRegions");

                    b.ToTable("TblRegions");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblRegistrationOption", b =>
                {
                    b.Property<int>("RegOptID")
                        .HasColumnType("int");

                    b.Property<string>("RegOptDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RegOptID");

                    b.ToTable("TblRegistrationOptions");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblSexType", b =>
                {
                    b.Property<int>("SexID")
                        .HasColumnType("int");

                    b.Property<string>("SexDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SexID");

                    b.ToTable("TblSexTypes");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblSpecies", b =>
                {
                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.Property<string>("SpeciesDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SpeciesID");

                    b.ToTable("TblSpecies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("AccessLevelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AccessLevelID")
                        .HasColumnType("int");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AgencyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgencyID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BarangayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CivilStatusCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentID")
                        .HasColumnType("int");

                    b.Property<string>("ExtensionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsEmailSent")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("McodeNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipalitiesCities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OTPDateSent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OTPSent")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OTPSentAttempt")
                        .HasColumnType("int");

                    b.Property<string>("PcodeNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhilSysIDNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PhilSysYN")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RcodeNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegOptID")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SexDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SexID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Signature")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("UploadValidID")
                        .HasColumnType("varbinary(max)");

                    b.HasIndex("AccessLevelID");

                    b.HasIndex("AgencyID");

                    b.HasIndex("RegOptID");

                    b.HasIndex("SexID");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblBarangays", b =>
                {
                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblMunicipalities", "TblMunicipalities")
                        .WithMany("TblBarangays")
                        .HasForeignKey("MunCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblMunicipalities");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblMunicipalities", b =>
                {
                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblProvinces", "TblProvinces")
                        .WithMany("TblMunicipalities")
                        .HasForeignKey("ProvCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblProvinces");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblProvinces", b =>
                {
                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblRegions", "TblRegions")
                        .WithMany("TblProvinces")
                        .HasForeignKey("Rcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblRegions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblAccessLevel", "AccessLevel")
                        .WithMany()
                        .HasForeignKey("AccessLevelID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblAgencyName", "AgencyName")
                        .WithMany()
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblRegistrationOption", "RegistrationOption")
                        .WithMany()
                        .HasForeignKey("RegOptID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BAIPetRegMobileApp.Api.Models.TblSexType", "SexType")
                        .WithMany()
                        .HasForeignKey("SexID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AccessLevel");

                    b.Navigation("AgencyName");

                    b.Navigation("RegistrationOption");

                    b.Navigation("SexType");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblMunicipalities", b =>
                {
                    b.Navigation("TblBarangays");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblProvinces", b =>
                {
                    b.Navigation("TblMunicipalities");
                });

            modelBuilder.Entity("BAIPetRegMobileApp.Api.Models.TblRegions", b =>
                {
                    b.Navigation("TblProvinces");
                });
#pragma warning restore 612, 618
        }
    }
}
