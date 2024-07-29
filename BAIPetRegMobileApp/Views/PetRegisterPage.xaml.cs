using SQLite;
using System.Windows.Input;


namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{

    List<string> dogBreeds = new List<string>()
{
    "Mixed",
    "ASPIN",
    "Affenpinscher",
    "Afghan Hound",
    "Airedate Terrier",
    "Akita Inu",
    "Alaskan Malamute",
    "African Bulldog",
    "American Bully",
    "Australian Cattle Dog",
    "Australia Dingo",
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
    "Biewer",
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
    "Bull Terrier",
    "Cairn",
    "Cane Corso",
    "Cavalier King Charles",
    "Chihuahua",
    "Chinese Crested Dog",
    "Chow Chow",
    "Cocker Spaniel",
    "Cotton De Tulear",
    "Curly Coated Retriever",
    "Dachshund",
    "Dalmatian",
    "Deerhound",
    "Doberman Pinscher",
    "Dogue de Bordeaux",
    "Dutch Shepherd",
    "English Bulldog",
    "English Setter",
    "English Springer Spaniel",
    "Exotic Bully",
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
    "Havanese Dog",
    "Hungarian Vizsla",
    "Irish",
    "Irish Red and White Setter",
    "Irish Setter",
    "Irish Water Spaniel",
    "Irish Wolfhound",
    "Italian Greyhound",
    "Italian Mastiff",
    "Jack Russell",
    "Japanese Chin",
    "Japanese Spitz",
    "Keeshond",
    "Kerry Blue",
    "Labrador Retriever",
    "Lhasa Apso",
    "Lowchen",
    "Maltese",
    "Mexican Hairless Terrier",
    "Miniature Pinscher",
    "Miniature Poodle",
    "Mongrel",
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
    "Shiba Inu",
    "Shih Tzu",
    "Shih Tzu Poddle",
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
    "Mixed",
    "Abyssinian",
    "Aegean",
    "American Curl",
    "American Shorthair",
    "American Wirehair",
    "Arabian Mau",
    "Asian",
    "Asian Semi-longhair",
    "Australian Mist",
    "Balinese",
    "Bambino",
    "Bengal",
    "Birman",
    "Bombay",
    "Brazilian Shorthair",
    "British Longhair",
    "British Semi-longhair",
    "British Shorthair",
    "Burmese",
    "Burmilla",
    "California Spangled",
    "Chantilly-Tiffany",
    "Chartreux",
    "Chausie",
    "Cheet0h",
    "Colorpoint Shorthair",
    "Cornish Rex",
    "Cymric or Manx Longhair",
    "Cyprus",
    "Devon Rex",
    "Dragon Li",
    "Domestic Long Hair",
    "Domestic Short Hair",
    "Dwarf cat or Dwelf",
    "Egyptian Mau",
    "European Shorthair",
    "Exotic Shorthair",
    "Foldex",
    "German Rex",
    "Havana Brown",
    "Highlander",
    "Himalayan or Colorpoint Persian",
    "Japanese Bobtail",
    "Javanese",
    "Karelian Bobtail",
    "Khao Manee",
    "Korat",
    "Korean Bobtail",
    "Korn Ja",
    "Kurilian Bobtail or Kuril Islands Bobtail",
    "LaPerm",
    "Lykoi",
    "Maine Coon",
    "Manx",
    "Mekong Bobtail",
    "Minskin",
    "Munchkin",
    "Norwegian Forest",
    "Nebelung",
    "Navajo Longhair",
    "Ocicat",
    "Ojos Azules",
    "Oregon Rex",
    "Oriental Bicolor",
    "Oriental Longhair",
    "Oriental Shorthair",
    "Others",
    "PerFold (Experimental Breed - WCF)",
    "Persian (Modern Persian Cat)",
    "Persian (Traditional Persian Cat)",
    "Peterbald",
    "Pixie-bob",
    "Raas",
    "Ragamuffin",
    "Ragdoll",
    "Russian Blue",
    "Russian White, Black and Tabby",
    "Sam Sawet",
    "Savannah",
    "Scottish Fold",
    "Selkirk Rex",
    "Serengeti",
    "Serrade petit",
    "Siamese",
    "Siberian",
    "Singapura",
    "Scottish Straight",
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

        SpeciesList.ItemsSource = listSpecies;
        BreedList.ItemsSource = new List<string> { "Please pick a species first" };


        List<string> listOwnership = new List<string>()
        {
            "Community Owned",
            "Household",
            "No Owner",
            "Neighborhood",
            "Owned",
            "Stray Animal"

        };
        OwnershipList.ItemsSource = listOwnership;


        List<string> ContactwAnimalList = new List<string>()
        {
            "Frequent",
            "Never",
            "Seldom",
            "Unknown"
        };
        ContactwOtherAnimals.ItemsSource = ContactwAnimalList;


        List<string> ListSex = new List<string>()
        {
            "Male",
            "Female",
            "Undetermine",

            "Mixed"
        };
        SexList.ItemsSource = ListSex;
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

    private async void OnTakePhoto1Clicked(object sender, EventArgs e)
    {
        await TakePhotoAsync(Image1);
    }

    private async void OnTakePhoto2Clicked(object sender, EventArgs e)
    {
        await TakePhotoAsync(Image2);
    }

    private async void OnTakePhoto3Clicked(object sender, EventArgs e)
    {
        await TakePhotoAsync(Image3);
    }

    private async void OnTakePhoto4Clicked(object sender, EventArgs e)
    {
        await TakePhotoAsync(Image4);
    }

    private async Task TakePhotoAsync(Image imageControl)
    {
        try
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Take a photo"
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

            BreedList.ItemsSource = dogBreeds;
        }
        else if (selectedSpecies == "Cat")
        {

            BreedList.ItemsSource = catBreeds;
        }
        else
        {
            BreedList.ItemsSource = new List<string> { "Please pick a species first" };
        }
    }

    private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (OtherRdBtn.IsChecked)
        {
            OtherEntryStack.IsVisible = true;
        }
        else
        {
            OtherEntryStack.IsVisible = false;
        }
    }

    private void OnStatusRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (DeadRadioButton.IsChecked)
        {
            DatePickerStack.IsVisible = true;
        }
        else
        {
            DatePickerStack.IsVisible = false;
        }
    }

    private void OnRadioTagButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (NoneRDbtn.IsChecked)
        {
            TagNumberEntryStack.IsVisible = false;
        }
        else
        {
            TagNumberEntryStack.IsVisible = true;
        }
    }
}
