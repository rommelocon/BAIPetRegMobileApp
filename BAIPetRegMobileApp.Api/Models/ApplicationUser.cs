using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAIPetRegMobileApp.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateRegistered { get; set; }

        public string? SecurityQuestion { get; set; }

        public string? Region { get; set; }

        public string? Province { get; set; }

        public string? Municipality { get; set; }

        public string? Barangay { get; set; }

        public string? Firstname { get; set; }

        [Column("mi")]
        public string? MiddleInitial { get; set; }

        public string? Lastname { get; set; }

        public string? Extension { get; set; }

        public DateTime? Birthday { get; set; }

        public string? SecurityLevel { get; set; }

        public string? SystemChosen { get; set; }

        public int? Rcodenum { get; set; }

        public int? Pcodenum { get; set; }

        public int? Mcodenum { get; set; }

        public int? Bcodenum { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Street { get; set; }

        [Column("SexDescription", TypeName = "nvarchar(50)")]
        public string? Gender { get; set; }

        public int? SexId { get; set; }

        public string? Role { get; set; }

        public string? Position { get; set; }

        public bool? Active { get; set; }

        public bool? Submitted { get; set; }

        public DateTime? DateSubmitted { get; set; }

        public byte[]? ProfilePicture { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Remarks { get; set; }

        [MaxLength(50)]
        public string? TIN { get; set; }

        [MaxLength(50)]
        public string? Nationality { get; set; }

        public int? NationalityID { get; set; }

        public bool? RegisteredPhilSys { get; set; }

        [MaxLength(50)]
        public string? PhilSysIDNumber { get; set; }

        public byte[]? Signature { get; set; }

        [MaxLength(50)]
        public string? ClientType { get; set; }

        public int? DocumentID { get; set; }

        [MaxLength(150)]
        public string? DocumentName { get; set; }

        public byte[]? ValidID { get; set; }

        public int? CivilStatusCode { get; set; }
    }
}
