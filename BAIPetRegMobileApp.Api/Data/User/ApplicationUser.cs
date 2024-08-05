﻿using Microsoft.AspNetCore.Identity;

namespace BAIPetRegMobileApp.Api.Data.User
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateRegistered { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? MiddleName { get; set; }
        public string? ExtensionName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? SexID { get; set; }
        public string? SexDescription { get; set; }
        public int? CivilStatusCode { get; set; }
        public string? Position { get; set; }
        public int? DocumentID { get; set; }
        public string? DocumentDescription { get; set; }
        public byte[]? UploadValidID { get; set; }
        public bool? PhilSysYN { get; set; }
        public string? PhilSysIDNumber { get; set; }
        public byte[]? Signature { get; set; }
        public bool? Active { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? AgencyID { get; set; }
        public string? AgencyDescription { get; set; }
        public int? AccessLevelID { get; set; }
        public string? AccessLevelDescription { get; set; }
        public string? RcodeNum { get; set; }
        public string? Region { get; set; }
        public string? PcodeNum { get; set; }
        public string? ProvinceName { get; set; }
        public string? McodeNum { get; set; }
        public string? MunicipalitiesCities { get; set; }
        public string? Bcode { get; set; }
        public string? BarangayName { get; set; }
        public string? FullAddress { get; set; }
        public bool? isEmailSent { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime? OTPSent { get; set; }
        public int? OTPSentAttempt { get; set; }
        public DateTime? OTPDateSent { get; set; }
        public int? RegOptID { get; set; }

        // Navigation properties for foreign keys
        public virtual RegistrationOption? RegistrationOption { get; set; }
        public virtual SexType? SexType { get; set; }
        public virtual AgencyName? AgencyName { get; set; }
        public virtual AccessLevel? AccessLevel { get; set; }
    }
}