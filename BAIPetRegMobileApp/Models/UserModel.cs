using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BAIPetRegMobileApp.Models
{
    public class UserModel : IdentityUser
    {
        [PersonalData]
        public DateTime? DateRegistered { get; set; }

        [PersonalData]
        public string SecurityQuestion { get; set; }

        [PersonalData]
        public string Region { get; set; }

        [PersonalData]
        public string Province { get; set; }

        [PersonalData]
        public string Municipality { get; set; }

        [PersonalData]
        public string Barangay { get; set; }

        [PersonalData]
        public string Firstname { get; set; }

        [PersonalData]
        public string mi { get; set; }

        [PersonalData]
        public string Lastname { get; set; }

        [PersonalData]
        public string Extension { get; set; }

        [PersonalData]
        public DateTime? Birthday { get; set; }

        [PersonalData]
        public string SecurityLevel { get; set; }

        [PersonalData]
        public string SystemChosen { get; set; }

        [PersonalData]
        public int? Rcodenum { get; set; }

        [PersonalData]
        public int? Pcodenum { get; set; }

        [PersonalData]
        public int? Mcodenum { get; set; }

        [PersonalData]
        public int? Bcodenum { get; set; }

        [PersonalData]
        public string Street { get; set; }

        [PersonalData]
        public string SexDescription { get; set; }

        [PersonalData]
        public int? SexId { get; set; }

        [PersonalData]
        public string Role { get; set; }

        [PersonalData]
        public string Position { get; set; }

        [PersonalData]
        public bool? Active { get; set; }

        [PersonalData]
        public bool? Submitted { get; set; }

        [PersonalData]
        public DateTime? DateSubmitted { get; set; }

        [PersonalData]
        public byte[] ProfilePicture { get; set; }

        [PersonalData]
        public string Remarks { get; set; }

        [PersonalData]
        public string TIN { get; set; }

        [PersonalData]
        public string Nationality { get; set; }

        [PersonalData]
        public int? NationalityID { get; set; }

        [PersonalData]
        public bool? RegisteredPhilSys { get; set; }

        [PersonalData]
        public string PhilSysIDNumber { get; set; }

        [PersonalData]
        public byte[] Signature { get; set; }

        [PersonalData]
        public string ClientType { get; set; }

        [PersonalData]
        public int? DocumentID { get; set; }

        [PersonalData]
        public string DocumentName { get; set; }

        [PersonalData]
        public byte[] ValidID { get; set; }

        [PersonalData]
        public int? CivilStatusCode { get; set; }

        // IdentityUser properties
        [PersonalData]
        public override string UserName { get; set; }

        [PersonalData]
        public override string NormalizedUserName { get; set; }

        [PersonalData]
        public override string Email { get; set; }

        [PersonalData]
        public override string NormalizedEmail { get; set; }

        public override bool EmailConfirmed { get; set; }

        public override string PasswordHash { get; set; }

        public override string SecurityStamp { get; set; }

        public override string ConcurrencyStamp { get; set; }

        [PersonalData]
        public override string PhoneNumber { get; set; }

        public override bool PhoneNumberConfirmed { get; set; }

        public override bool TwoFactorEnabled { get; set; }

        public override DateTimeOffset? LockoutEnd { get; set; }

        public override bool LockoutEnabled { get; set; }

        public override int AccessFailedCount { get; set; }
    }
}
