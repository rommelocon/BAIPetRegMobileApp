﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Models
{
    public class TblRegions
    {
        [Key]
        [Column("Rcode")]
        [StringLength(50)]
        public string Rcode { get; set; }

        [Column("Region")]
        [StringLength(100)]
        public string? RegionName { get; set; }

        [Column("PSGC")]
        [StringLength(50)]
        public string? PSGC { get; set; }

        [Column("Pop_2020")]
        public int? Population2020 { get; set; }

        // Navigation property
        public ICollection<TblProvinces>? TblProvinces { get; set; }
    }
}
