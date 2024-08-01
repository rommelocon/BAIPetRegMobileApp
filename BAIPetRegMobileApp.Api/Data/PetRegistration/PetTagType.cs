﻿using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class PetTagType
    {
        public string? TagID { get; set; }
        public string? TagDescription { get; set; }
        public string? SpeciesCode { get; set; }
        public string? SpeciesCommonName { get; set; }
        public virtual TagType? TagType { get; set; }
        public virtual SpeciesGroup? SpeciesGroup { get; set; }
    }
}