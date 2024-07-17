using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAIPetRegMobileApp.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateRegistered { get; set; } = DateTime.UtcNow;
        public int? RegOptID { get; set; }
        public string? Firstname { get; set; } = string.Empty;
        public string? Lastname { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        [MaxLength(50)]
        public string? ExtensionName { get; set; }
        public string? Birthday { get; set; }
        public int? SexID { get; set; }
        [MaxLength(50)]
        public string? SexDescription { get; set; }
        public int CivilStatusCode { get; set; }
        [MaxLength(250)]
        public string? Position { get; set; }
        public int? DocumentID { get; set; }
        [MaxLength(150)]
        public string? DocumentDescription { get; set; }
        public byte[]? UploadValidID { get; set; }
        public bool? PhilSysYN { get; set; }
        [MaxLength(50)]
        public string? PhilSysIDNumber { get; set; }
        public byte[]? Signature { get; set; }
        public bool? Active { get; set; }
        public byte[]? ProfilePicture { get; set; }
        [MaxLength(10)]
        public string? AgencyID { get; set; }
        [MaxLength(50)]
        public string? AgencyDescription { get; set; }
        public int? AccessLevelID { get; set; }
        [MaxLength(50)]
        public string? AccessLevelDescription { get; set; }
        [MaxLength(50)]
        public string? RcodeNum { get; set; }
        [MaxLength(100)]
        public string? Region { get; set; }
        [MaxLength(50)]
        public string? PcodeNum { get; set; }
        [MaxLength(100)]
        public string? ProvinceName { get; set; }
        [MaxLength(50)]
        public string? McodeNum { get; set; }
        [MaxLength(100)]
        public string? MunicipalitiesCities { get; set; }
        [MaxLength(50)]
        public string? Bcode { get; set; }
        [MaxLength(150)]
        public string? BarangayName { get; set; }
        public string? FullAddress { get; set; }
        public bool? isEmailSent { get; set; }
        [MaxLength(50)]
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        [MaxLength(50)]
        public string? MobileNumber { get; set; }
        public DateTime? OTPSent { get; set; }
        public int? OTPSentAttempt { get; set; }
        public DateTime? OTPDateSent { get; set; }

        // Navigation properties
        [ForeignKey("RegOptID")]
        public virtual RegistrationOption? RegistrationOption { get; set; }

        [ForeignKey("SexID")]
        public virtual SexType? SexType { get; set; }

        [ForeignKey("AgencyID")]
        public virtual AgencyName? Agency { get; set; }

        [ForeignKey("AccessLevelID")]
        public virtual AccessLevel? AccessLevel { get; set; }

        [ForeignKey("Bcode")]
        public virtual Barangay? Barangay { get; set; }
    }
}