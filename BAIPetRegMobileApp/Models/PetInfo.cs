using System.Security.Cryptography.X509Certificates;

namespace BAIPetRegMobileApp.Models
{
    public class PetInfo
    {
    public string EntryPetname { get; set; }
    public string ownershipList { get; set; }
    public string speciesList { get; set; }
    public string breedList { get; set; }
    //public string date { get; set; }
    public string sexList { get; set; }
    public int PetAge { get; set; }
    public int PetCount { get; set; }
    }
}