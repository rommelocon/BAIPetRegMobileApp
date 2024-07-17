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
    public string? RemarksEditor { get; set; }
    public string? PetOriginLocal { get; set; }
    public string? PetOriginOther { get; set; }
    public string? StatusLive { get; set; }
    public string? StatusDead {get; set; }
    public byte[]? Image1 { get; set; }
    public byte[]? Image2 { get; set; }
    public byte[]? Image3 { get; set;}
    public byte[]? Image4 { get; set; }
    }

}