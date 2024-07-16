using System.Security.Cryptography.X509Certificates;

namespace BAIPetRegMobileApp.Models
{
    public class PetInfo
    {
    public string? EntryPetname { get; set; }
    public string? ownershipList { get; set; }
    public string? speciesList { get; set; }
    public string? breedList { get; set; }
    //public string date { get; set; }
    public DateTime BirthDate { get; set; }
    public string? sexList { get; set; }
    public int PetWeight { get; set; }
    public string? PetColor { get; set; }
    public int EntryTagNumber { get; set; }
    }
}