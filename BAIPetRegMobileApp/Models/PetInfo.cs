using System.Security.Cryptography.X509Certificates;

namespace BAIPetRegMobileApp.Models
{
    public class PetInfo
    {
    public string? EntryPetname { get; set; }
    public List <string>? OwnershipList { get; set; }
    public List <string>? SpeciesList { get; set; }
    public List<string>? BreedList { get; set; }
    public DateTime BirthDate { get; set; }
    public List<string>? SexList { get; set; }
    public List<string>? HabitatList {  get; set; }
    public List<string>? TagTypeList { get; set; }
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