using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserModel : IdentityUser
{
    public DateTime? DateRegistered { get; set; } // SMALLDATETIME

    public int? RegOptID { get; set; } // INT

    [MaxLength]
    [Column(TypeName = "nvarchar(MAX)")]
    [DefaultValue("")]
    public string Firstname { get; set; }

    [MaxLength]
    [Column(TypeName = "nvarchar(MAX)")]
    [DefaultValue("")]
    public string Lastname { get; set; }

    [MaxLength(50)]
    public string MiddleName { get; set; } // NVARCHAR(50)

    [MaxLength(50)]
    public string ExtensionName { get; set; } // NVARCHAR(50)

    public DateTime? Birthday { get; set; } // DATE

    public int? SexID { get; set; } // INT

    [MaxLength(50)]
    public string SexDescription { get; set; } // NVARCHAR(50)

    public int? CivilStatusCode { get; set; } // INT

    [MaxLength(250)]
    public string Position { get; set; } // NVARCHAR(250)

    public int? DocumentID { get; set; } // INT

    [MaxLength(150)]
    public string DocumentDescription { get; set; } // NVARCHAR(150)

    public byte[] UploadValidID { get; set; } // VARBINARY(MAX)

    public bool? PhilSysYN { get; set; } // BIT

    [MaxLength(50)]
    public string PhilSysIDNumber { get; set; } // NVARCHAR(50)

    public byte[] Signature { get; set; } // VARBINARY(MAX)

    public bool? Active { get; set; } // BIT

    public byte[] ProfilePicture { get; set; } // VARBINARY(MAX)

    [MaxLength(10)]
    public string AgencyID { get; set; } // NVARCHAR(10)

    [MaxLength(50)]
    public string AgencyDescription { get; set; } // NVARCHAR(50)

    public int? AccessLevelID { get; set; } // INT

    [MaxLength(50)]
    public string AccessLevelDescription { get; set; } // NVARCHAR(50)

    [MaxLength(50)]
    public string RcodeNum { get; set; } // NVARCHAR(50)

    [MaxLength(100)]
    public string Region { get; set; } // NVARCHAR(100)

    [MaxLength(50)]
    public string PcodeNum { get; set; } // NVARCHAR(50)

    [MaxLength(100)]
    public string ProvinceName { get; set; } // NVARCHAR(100)

    [MaxLength(50)]
    public string McodeNum { get; set; } // NVARCHAR(50)

    [MaxLength(100)]
    public string MunicipalitiesCities { get; set; } // NVARCHAR(100)

    [MaxLength(50)]
    public string Bcode { get; set; } // NVARCHAR(50)

    [MaxLength(150)]
    public string BarangayName { get; set; } // NVARCHAR(150)

    [MaxLength]
    public string FullAddress { get; set; } // NVARCHAR(MAX)

    public bool? isEmailSent { get; set; } // BIT

    [MaxLength(50)]
    public string ApprovedBy { get; set; } // NVARCHAR(50)

    public DateTime? ApprovedDate { get; set; } // DATETIME

    [MaxLength(50)]
    public string MobileNumber { get; set; } // NVARCHAR(50)

    public DateTime? OTPSent { get; set; } // DATETIME

    public int? OTPSentAttempt { get; set; } // INT

    public DateTime? OTPDateSent { get; set; } // DATETIME
}