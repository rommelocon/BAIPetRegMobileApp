using SQLite;

namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
    public string selectedOwnership;
    public PetRegisterPage()
    {
        InitializeComponent();

        List<string> listOwnership = new List<string>()
        {
            "Ownership001",
            "Ownership002",
            "Ownership003"
        };
        ownershipList.ItemsSource = listOwnership;

        List<string> listSpecies = new List<string>()
        {
            "Species001",
            "Species002",
            "Species003"
        };
        speciesList.ItemsSource = listSpecies;

        List<string> listBreed = new List<string>()
        {
            "Breed001",
            "Breed002",
            "Breed003"
        };
        breedList.ItemsSource = listBreed;

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
        string petName = EntryPetName.Text;
        Console.WriteLine(petName);
        Console.WriteLine(ownershipList);
        //if (petNameValidator.IsNotValid)
        //{
        //    DisplayAlert("Error", "Name is required", "OK");
        //    return;
        //}



    }

   

}
