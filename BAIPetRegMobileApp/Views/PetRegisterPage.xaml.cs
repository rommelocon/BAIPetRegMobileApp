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
        if (petNameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required", "OK");
            return;
        }
        //Store on a new variable input or Selected data

        //string PetName = EntryPetName.Text;
        //Console.WriteLine(PetName);
        Shell.Current.GoToAsync(nameof(FinalCheckingPage));
    }
}