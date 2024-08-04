using System;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.DTOs
{
    public class PetRegistrationDTO
    {
        [Key]
        [StringLength(50)]
        public string? PetRegistrationID { get; set; }

        public DateTime? DateEncocde { get; set; }
        public DateTime? DateRegistered { get; set; }

        [StringLength(5)]
        public string? TagID { get; set; }

        [StringLength(50)]
        public string? TagDescription { get; set; }

        [StringLength(50)]
        public string? TagNo { get; set; }

        [StringLength(50)]
        public string? Alias { get; set; }

        [StringLength(100)]
        public string? ClientID { get; set; }

        [StringLength(100)]
        public string? ClientName { get; set; }

        public int? ClientSexID { get; set; }

        [StringLength(50)]
        public string? ClientSexDescription { get; set; }

        [StringLength(50)]
        public string? ClientRcode { get; set; }

        [StringLength(100)]
        public string? ClientRegion { get; set; }

        [StringLength(50)]
        public string? ClientProvCode { get; set; }

        [StringLength(100)]
        public string? ClientProvinceName { get; set; }

        [StringLength(50)]
        public string? ClientMunCode { get; set; }

        [StringLength(150)]
        public string? ClientMunicipalities { get; set; }

        [StringLength(50)]
        public string? ClientBcode { get; set; }

        [StringLength(150)]
        public string? ClientBarangayName { get; set; }

        public string? OwnershipType { get; set; }

        public string? OwnershipTypeDescription { get; set; }

        [StringLength(100)]
        public string? PetName { get; set; }

        public DateOnly? PetDateofBirth { get; set; }

        public int? PetSexID { get; set; }

        [StringLength(20)]
        public string? PetSexDescription { get; set; }

        public int? AnimalFemaleClassID { get; set; }

        [StringLength(50)]
        public string? AnimalFemalClassification { get; set; }

        public int? NumberOffspring { get; set; }

        public double? Weight { get; set; }
        public double? AgeInMonth { get; set; }

        [StringLength(10)]
        public string? SpeciesCode { get; set; }

        [StringLength(50)]
        public string? SpeciesCommonName { get; set; }

        [StringLength(10)]
        public string? BreedID { get; set; }

        [StringLength(50)]
        public string? BreedDescription { get; set; }

        [StringLength(10)]
        public string? AnimalColorID { get; set; }

        [StringLength(50)]
        public string? AnimalColorDescription { get; set; }

        [StringLength(50)]
        public string? PetOrigin { get; set; }

        public int? StatusID { get; set; }

        [StringLength(50)]
        public string? StatusDescription { get; set; }

        public DateTime? DateDied { get; set; }

        [StringLength(50)]
        public string? ReportOfficer { get; set; }

        public string? PetImage1 { get; set; }
        public string? PetImage2 { get; set; }
        public string? PetImage3 { get; set; }
        public string? PetImage4 { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(256)]
        public string? UserName { get; set; }

        [StringLength(300)]
        public string? Remarks { get; set; }
    }
}
