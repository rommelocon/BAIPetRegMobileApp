using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.User
{
    public class SexType
    {
        [Key]
        public int SexID { get; set; } // Primary key
        public string? SexDescription { get; set; }
    }
}
