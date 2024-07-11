using SQLite;
using System.Windows.Input;

namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
    public string selectedOwnership;

    List<string> dogBreeds = new List<string>()
{
    "Affenpinscher",
    "Afghan Hound",
    "Golden Retriever",
    "Airedale Terrier",
    "Akita Inu",
    "Alaskan Malamute",
    "ASPIN",
    "Australian Cattle Dog",
    "Australian Dingo",
    "Australian Kelpie",
    "Australian Shepherd",
    "Australian Silky Terrier",
    "Australian Terrier",
    "Basenji",
    "Basset Hound",
    "Beagle",
    "Bearded Collie",
    "Bedlington",
    "Belgian Malinois",
    "Bernese Mountain Dog",
    "Bichon Frise",
    "Bloodhound",
    "Border",
    "Border Collie",
    "Borzoi",
    "Boston Terrier",
    "Boxer",
    "Briard",
    "British Bulldog",
    "Bull",
    "Bull Mastiff",
    "Cairn",
    "Cavalier King Charles",
    "Chihuahua",
    "Chinese Crested Dog",
    "Chow Chow",
    "Cocker Spaniel",
    "Curly Coated Retriever",
    "Dachshund",
    "Dalmatian",
    "Deerhound",
    "Doberman Pinscher",
    "Dogue de Bordeaux",
    "English Setter",
    "English Springer Spaniel",
    "Field Spaniel",
    "Finnish Spitz",
    "Foxhound",
    "Fox Terrier",
    "French Bulldog",
    "German Pinscher",
    "German Pointer",
    "German Shepherd",
    "Golden Retriever",
    "Gordon Setter",
    "Great Dane",
    "Greyhound",
    "Hungarian Vizsla",
    "Irish Setter",
    "Irish Red and White Setter",
    "Irish Water Spaniel",
    "Irish Wolfhound",
    "Italian Greyhound",
    "Jack Russell",
    "Japanese Chin",
    "Keeshond",
    "Kerry Blue",
    "Labrador Retriever",
    "Lhasa Apso",
    "Lowchen",
    "Maltese",
    "Miniature Pinscher",
    "Miniature Poodle",
    "Mixed",
    "Newfoundland",
    "Norwich Terrier",
    "Old English Sheepdog",
    "Papillon",
    "Pekingese",
    "Pharaoh Hound",
    "Pointer",
    "Pomeranian",
    "Portuguese Water Dog",
    "Pug",
    "Puli",
    "Pyrenean Mountain Dog",
    "Rhodesian Ridgeback",
    "Rottweiler",
    "Rough Collie",
    "Saluki",
    "Samoyed",
    "Schnauzer",
    "Schipperke",
    "Scottish Terrier",
    "Shar Pei",
    "Shetland Sheepdog",
    "Shih Tzu",
    "Siberian Husky",
    "Smooth Collie",
    "St. Bernard",
    "Staffordshire Bull Terrier",
    "Standard Poodle",
    "Tibetan Terrier",
    "Tibetan Spaniel",
    "Toy Poodle",
    "Weimaraner",
    "Welsh Corgi",
    "West Highland White Terrier",
    "Whippet",
    "Yorkshire Terrier"
};
    List<string> catBreeds = new List<string>()
{
    "Siamese",
    "Maine Coon",
    "Persian",
    "Bengal",
    "Sphynx"
};

    List<string> selectedBreeds = new List<string>();


    public PetRegisterPage()
    {
        InitializeComponent();



        List<string> listSpecies = new List<string>()
            {
                "Dog",
                "Cat"
            };

        speciesList.ItemsSource = listSpecies;
        breedList.ItemsSource = new List<string> { "Please pick a species first" };


        List<string> listOwnership = new List<string>()
        {
            "Personal Ownership",
            "Family Ownership",
            "Shared Ownership",
            "Foster Ownership",
            "Service or Assistance",
            "Working Animals",
            "Breeder Ownership",
            "Rescue Organization"

        };
        ownershipList.ItemsSource = listOwnership;



        List<string> listSex = new List<string>()
        {
            "Male",
            "Female"
        };
        sexList.ItemsSource = listSex;

    }

    public void OnOwnershipListSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        string selectedOwnership = (string)picker.SelectedItem;
    }

    //imagepicker function

    private async void OnSelectImage1Clicked(object sender, EventArgs e)
    {
        await PickImageAsync(Image1);
    }

    private async void OnSelectImage2Clicked(object sender, EventArgs e)
    {
        await PickImageAsync(Image2);
    }

    private async void OnSelectImage3Clicked(object sender, EventArgs e)
    {
        await PickImageAsync(Image3);
    }

    private async void OnSelectImage4Clicked(object sender, EventArgs e)
    {
        await PickImageAsync(Image4);
    }

    private async Task PickImageAsync(Image imageControl)
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imageControl.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
    private void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FinalCheckingPage));
    }

    private void OnSpeciesSelected(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedSpecies = picker.SelectedItem as string;


        if (selectedSpecies == "Dog")
        {

            breedList.ItemsSource = dogBreeds;
        }
        else if (selectedSpecies == "Cat")
        {

            breedList.ItemsSource = catBreeds;
        }
        else
        {
            breedList.ItemsSource = new List<string> { "Please pick a species first" };
        }
    }





}
