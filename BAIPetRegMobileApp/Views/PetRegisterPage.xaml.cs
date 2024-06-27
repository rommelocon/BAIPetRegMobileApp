namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
	public PetRegisterPage()
	{
		InitializeComponent();

	}

    private void Picker_Focused(object sender, FocusEventArgs e)
    {

    }

    private async void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        // Check if all required fields are filled
        bool isFormValid = ValidateForm(); // Implement your validation logic

        if (isFormValid)
        {
            // Navigate to the final checking page
            await Navigation.PushAsync(new FinalCheckingPage());
        }
        else
        {
            // Handle validation errors, show message to user
            await DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
        }
    }

    private bool ValidateForm()
    {
        // Example validation logic for required fields
        bool isValid = true;

        // Validate Pet's Name Entry
        if (string.IsNullOrWhiteSpace(EntryPetName.Text))
            isValid = false;

        // Validate Type of Ownership Picker
        if (PickerTypeOfOwnership.SelectedIndex == -1)
            isValid = false;

        // Validate other required fields as needed

        // Optional field: Tag Number
        // Skip validation if EntryTagNumber is empty or null
        if (!string.IsNullOrWhiteSpace(EntryTagNumber.Text))

        {
            // Add specific validation logic for Tag Number if needed
            // Example:
            // if (EntryTagNumber.Text.Length != 10)
            //     isValid = false;
        }

        return isValid;
    }

}