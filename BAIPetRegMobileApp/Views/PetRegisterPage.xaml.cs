using SQLite;

namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
 



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

        List<string> listRegion = new List<string>()
        {
            "Region001",
            "Region002",
            "Region003"
        };
        regionList.ItemsSource = listRegion;

        List<string> listProvince = new List<string>()
        {
            "Province001",
            "Province002",
            "Province003"
        };
        provinceList.ItemsSource = listProvince;

        List<string> listMunicipality = new List<string>()
        {
            "Municipality001",
            "Municipality002",
            "Municipality003"
        };
        municipalityList.ItemsSource = listMunicipality;

        List<string> listOwnerSex = new List<string>()
        {
            "Male",
            "Female"
        };
        ownerSexList.ItemsSource = listOwnerSex;

    }

    private void BtnSubmitError(object sender, EventArgs e)
    {
        if (petNameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required", "OK");
            return;
        }
    }
    
    private void OnOwnershipListSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        string selectedOwnership = (string)picker.SelectedItem;
        Console.WriteLine($"Selected Ownership: {selectedOwnership}");

        // Now, selectedOwnership contains the selected value.
    }

    //private void Picker_Focused(object sender, FocusEventArgs e)
    //{

    //}

    private void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FinalCheckingPage));
    }
  
}
