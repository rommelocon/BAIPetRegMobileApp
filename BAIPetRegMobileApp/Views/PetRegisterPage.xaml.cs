namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
    public string? selectedOwnership;

    public PetRegisterPage()
    {
        InitializeComponent();

        InitializePickerData();
    }

    private void InitializePickerData()
    {
        ownershipList.ItemsSource = new List<string>
        {
            "Ownership001",
            "Ownership002",
            "Ownership003"
        };

        speciesList.ItemsSource = new List<string>
        {
            "Species001",
            "Species002",
            "Species003"
        };

        breedList.ItemsSource = new List<string>
        {
            "Breed001",
            "Breed002",
            "Breed003"
        };

        sexList.ItemsSource = new List<string>
        {
            "Male",
            "Female"
        };

        regionList.ItemsSource = new List<string>
        {
            "Region001",
            "Region002",
            "Region003"
        };

        provinceList.ItemsSource = new List<string>
        {
            "Province001",
            "Province002",
            "Province003"
        };

        municipalityList.ItemsSource = new List<string>
        {
            "Municipality001",
            "Municipality002",
            "Municipality003"
        };

        ownerSexList.ItemsSource = new List<string>
        {
            "Male",
            "Female"
        };
    }

    private void OnOwnershipListSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedOwnership = (string)picker.SelectedItem;
    }

    private async void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FinalCheckingPage));
        string petName = EntryPetName.Text;
        Console.WriteLine(petName);
        Console.WriteLine(selectedOwnership);

        // Perform further actions like validation or saving data here
    }
}